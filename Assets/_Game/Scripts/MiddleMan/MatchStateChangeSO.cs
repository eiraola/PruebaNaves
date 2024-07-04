using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MatchStateChanger", menuName = "ScriptableObjects/System/Gameplay/Matcth state changer", order = 1)]
public class MatchStateChangeSO : ScriptableObject
{
    public Action onGameStop;
    public Action onGameRestart;
    public Action onGameInit;

    public void StopGame()
    {
        onGameStop?.Invoke();
    }

    public void RestartGame()
    {
        onGameRestart?.Invoke();
    }

    public void InitGame()
    {
        onGameInit?.Invoke();
    }
}
