using UnityEngine;

[CreateAssetMenu(menuName = "Settings/New Volume Settings")]
public class VolumeSettings : ConfigSettings
{
    [Range(0f, 1f)] public float volume = 1f;
}