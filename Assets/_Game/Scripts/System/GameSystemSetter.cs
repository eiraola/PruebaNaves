using UnityEngine;

public class GameSystemSetter : MonoBehaviour
{
    [SerializeField] private int _targetFrameRate = 60;
    [SerializeField] private MatchStateChangeSO _matchStateChangeSO;
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = _targetFrameRate;
    }
}
