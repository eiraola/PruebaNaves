using System;
using UnityEngine;


[CreateAssetMenu(fileName = "NewWindSignal", menuName = "ScriptableObjects/System/Gameplay/Wind Signal", order = 1)]
public class WindDirectionSignalSenderSO : ScriptableObject
{
    [NonSerialized]
    private EWindDirection _currentWindDirection = EWindDirection.Up;
    public Action<EWindDirection> onWindChange;

    public EWindDirection CurrentWindDirection { get => _currentWindDirection;}

    public Vector2 CurrentWindDirectionValue {
        get 
        {
            switch (_currentWindDirection)
            {
                case EWindDirection.Up:
                    return Vector2.up;
                case EWindDirection.Down:
                    return -Vector2.up;
                case EWindDirection.Left:
                    return -Vector2.right;
                case EWindDirection.Right:
                    return Vector2.right;
                default:
                    return Vector2.up;
            };
        } 
    }

    public void ChangeWind(EWindDirection direction)
    {
        onWindChange?.Invoke(direction);
        _currentWindDirection = direction;
    }
}
