using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScoreSystem", menuName = "ScriptableObjects/System/Match/Score system", order = 1)]
public class MatchScoreSO : ScriptableObject
{
    [SerializeField] private int _scoreByDead = 1;
    [NonSerialized]
    private int _teamOneScore = 0;
    [NonSerialized]
    private int _teamTwoScore = 0;
    public Action onScoreChanged;

    public int TeamOneScore { get => _teamOneScore; }
    public int TeamTwoScore { get => _teamTwoScore; }

    public void AddTeamOneScore()
    {  
        _teamOneScore += _scoreByDead;
        onScoreChanged?.Invoke();
    }

    public void AddTeamTwoScore()
    {
        _teamTwoScore += _scoreByDead;
        onScoreChanged?.Invoke();
    }

}
