using UnityEngine;

public enum EClip
{
    ButtonPress,
    Shoot,
    Impact,
    Die,
    Win,
    Boost
}

[System.Serializable]
public class SoundClip 
{
    public AudioClip clip;
    public EClip clipType;
}
