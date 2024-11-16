using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioSource _bgmSource;
    [SerializeField] AudioMixer _mixer;
    [SerializeField] VolumeSettings _volumeSettings;
    [SerializeField] AudioData[] _tracks;
    private int _trackIndex = 0;
    public int TrackIndex
    {
        get => _trackIndex;
        private set
        {
            if (value > _tracks.Length - 1)
            {
                _trackIndex = 0;
            }
            else if (value < 0)
            {
                _trackIndex = _tracks.Length - 1;
            }
            else
            {
                _trackIndex = value;
            }
            PlayTrack(_trackIndex);
        }
    }
    private void OnEnable()
    {
        _volumeSettings.JsonLoaded += OnJsonLoaded;
    }
    private void OnDisable()
    {
        _volumeSettings.JsonLoaded -= OnJsonLoaded;
    }

    private void OnJsonLoaded(ConfigSettings settings)
    {
        var volumeSettings = settings as VolumeSettings;
        _mixer.SetFloat("masterVolume", Mathf.Log10(volumeSettings.volume) * 20f);
    }

    private void Start()
    {
        PlayTrack(TrackIndex);
    }
    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.A)) { PlayPreviousTrack(); }
        // if (Input.GetKeyDown(KeyCode.D)) { PlayNextTrack(); }
    }
    public void PlayTrack(int index)
    {
        PlayTrack(_tracks[index]);
    }
    public void PlayTrack(AudioData audioTrack)
    {
        _bgmSource.clip = audioTrack.Clip;
        _bgmSource.volume = audioTrack.Volume;
        _bgmSource.Play();
    }

    public void PlayNextTrack()
    {
        TrackIndex++;
    }

    public void PlayPreviousTrack()
    {
        TrackIndex--;
    }
}
