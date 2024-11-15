using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioSource _bgmSource;
    [SerializeField] VolumeSettings _settings;
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

    private void Start()
    {
        PlayTrack(TrackIndex);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) { PlayPreviousTrack(); }
        if (Input.GetKeyDown(KeyCode.D)) { PlayNextTrack(); }
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
