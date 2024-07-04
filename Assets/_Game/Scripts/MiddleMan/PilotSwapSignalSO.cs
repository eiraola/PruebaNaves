using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPilotSwapSignal", menuName = "ScriptableObjects/System/Gameplay/Pilot swap signal", order = 1)]
public class PilotSwapSignalSO : ScriptableObject
{
    public Action<EPilot> onPilotSwap;

    public void SwapPilot(EPilot pilot)
    {
        onPilotSwap?.Invoke(pilot);
    }
}
