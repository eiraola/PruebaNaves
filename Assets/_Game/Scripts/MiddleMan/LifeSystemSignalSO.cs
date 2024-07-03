using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLifeSystem", menuName = "ScriptableObjects/System/Gameplay/Life System Signal", order = 1)]
public class LifeSystemSignalSO : ScriptableObject
{
    public Action<float> onLifeChanged;

    public void LifeChanged(float lifePercent) 
    { 
        onLifeChanged?.Invoke(lifePercent);
    }
}
