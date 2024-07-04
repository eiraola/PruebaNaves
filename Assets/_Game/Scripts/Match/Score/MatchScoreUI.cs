using TMPro;
using UnityEngine;

public class MatchScoreUI : MonoBehaviour
{
    [SerializeField] private MatchScoreSO _matchScoreSO;
    [SerializeField] private TextMeshProUGUI _playerOneScoreUI;
    [SerializeField] private TextMeshProUGUI _playerTwoScoreUI;

    private void OnEnable()
    {
        _matchScoreSO.onScoreChanged += UpdateUI;
    }

    private void OnDisable()
    {
        _matchScoreSO.onScoreChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        _playerOneScoreUI.text = _matchScoreSO.TeamOneScore.ToString();
        _playerTwoScoreUI.text = _matchScoreSO.TeamTwoScore.ToString();
    }
}
