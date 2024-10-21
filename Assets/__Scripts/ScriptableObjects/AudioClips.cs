using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AudioClips : ScriptableObject
{
    public float MinPitch;
    public float MaxPitch;
    public float Volume;

    [Range(1, 10)]
    public int Frequency;

    public List<AudioClip> Clips = new List<AudioClip>();
}
