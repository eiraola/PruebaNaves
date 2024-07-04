using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New VFX Signal", menuName = "ScriptableObjects/System/Gameplay/Vfx signal sender", order = 1)]
public class VFXSignalSenderSO : ScriptableObject
{
    public Action<ETeam, Transform> onVFXPlay;

    public void PlayVFX(ETeam team, Transform transform)
    {
        onVFXPlay?.Invoke(team, transform);
    }
}
