using UnityEngine;

public class MatchScoreAdder : MonoBehaviour
{
    [SerializeField] private MatchScoreSO _matchScoreSO;
    
    public void AddTeamOneScore()
    {
        _matchScoreSO.AddTeamOneScore();
    }

    public void AddTeamTwoScore()
    {
        _matchScoreSO.AddTeamTwoScore();
    }
}
