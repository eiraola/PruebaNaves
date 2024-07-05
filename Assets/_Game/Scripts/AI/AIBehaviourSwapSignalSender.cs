using UnityEngine;

public class AIBehaviourSwapSignalSender : MonoBehaviour
{
    [SerializeField] private AIBehaviourSwapperSignalSO _aiBehaviourSwapperSO;

    public void SetEasyMode()
    {
        _aiBehaviourSwapperSO.SetEasyMode();
    }

    public void SetHardMode()
    {
        _aiBehaviourSwapperSO.SetHardMode();
    }
}
