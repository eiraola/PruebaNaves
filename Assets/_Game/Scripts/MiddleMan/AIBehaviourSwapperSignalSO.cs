using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AI BehaviourChange Signal", menuName = "ScriptableObjects/System/AI/Behaviour swap signal sender", order = 1)]

public class AIBehaviourSwapperSignalSO : ScriptableObject
{
    public Action onEasyModeSet;
    public Action onHardModeSet;

    public void SetEasyMode()
    {
        onEasyModeSet?.Invoke();
    }

    public void SetHardMode() 
    {
        onHardModeSet?.Invoke();
    }
}
