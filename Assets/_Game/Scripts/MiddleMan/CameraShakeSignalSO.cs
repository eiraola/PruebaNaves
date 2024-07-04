using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraShakeSignal", menuName = "ScriptableObjects/System/Gameplay/Camera shake", order = 1)]
public class CameraShakeSignalSO : ScriptableObject
{
    public Action onCameraShake;

    public void ShakeCamera()
    {
        onCameraShake?.Invoke();
    }
}
