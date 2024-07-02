using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBoostSignal", menuName = "ScriptableObjects/System/Gameplay/Boost Signal", order = 1)]
public class BoostSignalSO : ScriptableObject
{
    public Action<float> onAccelerationCDValueChanged;
    private float _boostVelocity = 0.0f;

    public float BoostVelocity { get => _boostVelocity;}

    public void SetBoostValue(float boostValue)
    {
        _boostVelocity = boostValue;
    }

    public void AccelrationCDValueChanged(float newValue)
    {
        onAccelerationCDValueChanged?.Invoke(newValue);
    }
}
