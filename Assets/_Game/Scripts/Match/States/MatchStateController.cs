using UnityEngine;

public class MatchStateController : MonoBehaviour
{
    [SerializeField] private MatchStateChangeSO _matchStateChangerSO;
    [SerializeField] private MatchScoreSO _matchScoreSO;
    [SerializeField] private UIMenuFade _restartMenu;

    private void OnEnable()
    {
        _matchScoreSO.onScoreChanged += StopGame;
    }

    private void OnDisable()
    {
        _matchScoreSO.onScoreChanged -= StopGame;
    }

    public void InitializeGame()
    {
        _matchStateChangerSO.InitGame();
    }

    public void StopGame()
    {
        _matchStateChangerSO.StopGame();
        _restartMenu.gameObject.SetActive(true);
    }

    public void ResetGame()
    {
        _matchStateChangerSO.RestartGame();
    }
}
