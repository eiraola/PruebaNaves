using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBoostSignal", menuName = "ScriptableObjects/System/Gameplay/Boost Signal", order = 1)]
public class BoostSignalSO : ScriptableObject
{
    public Action<float> onAccelerationCDValueChanged;

    public void AccelrationCDValueChanged(float newValue)
    {
        onAccelerationCDValueChanged?.Invoke(newValue);
    }
}
