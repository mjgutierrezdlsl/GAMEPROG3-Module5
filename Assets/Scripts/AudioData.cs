using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/New Audio Data")]
public class AudioData : ScriptableObject
{
    [field: SerializeField] public AudioClip Clip { get; private set; }
    [field: SerializeField, Range(0f, 1f)] public float Volume { get; private set; } = 1f;
}
