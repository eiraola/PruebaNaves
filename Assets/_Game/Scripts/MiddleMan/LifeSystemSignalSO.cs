using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLifeSystem", menuName = "ScriptableObjects/System/Gameplay/Life System Signal", order = 1)]
public class LifeSystemSignalSO : ScriptableObject
{
    [SerializeField] private CameraShakeSignalSO _cameraShake;
    public Action<float> onLifeChanged;

    public void LifeChanged(float lifePercent) 
    {
        if (_cameraShake) 
        { 
            _cameraShake.ShakeCamera();
        }
        onLifeChanged?.Invoke(lifePercent);
    }
}
