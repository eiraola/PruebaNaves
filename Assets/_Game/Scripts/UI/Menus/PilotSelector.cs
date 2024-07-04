using UnityEngine;

public class PilotSelector : MonoBehaviour
{
    [SerializeField] private PilotSwapSignalSO _pilotSignalSwapper;

    public void SwapToAI()
    {
        _pilotSignalSwapper.SwapPilot(EPilot.AI);
    }

    public void SwapToPlayer()
    {
        _pilotSignalSwapper.SwapPilot(EPilot.Player);
    }
}
