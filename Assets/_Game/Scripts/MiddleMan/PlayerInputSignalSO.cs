using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewImputSignal", menuName = "ScriptableObjects/System/Gameplay/Input signal", order = 1)]

public class PlayerInputSignalSO : ScriptableObject
{
    public Action<float> onRotateInputPress;
    public Action onBoostInputPress;
    public Action onFireInputPress;

    public void RotationInputPress(float inputValue)
    {
        onRotateInputPress?.Invoke(inputValue);
    }

    public void BoostInputPress()
    { 
        onBoostInputPress?.Invoke();
    }

    public void FireInputPress() {
        onFireInputPress?.Invoke();
    }
}
