using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotSwapper : MonoBehaviour
{
    [SerializeField] private PilotSwapSignalSO _pilotSwapSignal;
    [SerializeField] private PlayerInputSignalSO _aiBrain;
    [SerializeField] private PlayerInputSignalSO _player;
    [SerializeField] private PlayerInputHandler _handler;
    [SerializeField] private GameObject _aiBrainGO;

    private void OnEnable()
    {
        _pilotSwapSignal.onPilotSwap += SwapPilot;
    }

    private void OnDisable()
    {
        _pilotSwapSignal.onPilotSwap -= SwapPilot;
    }

    private void SwapPilot(EPilot pilot)
    {
        switch (pilot)
        {
            case EPilot.Player:
                _handler.SetInputSignal(_player);
                _aiBrainGO.SetActive(false);
                break;
            case EPilot.AI:
                _handler.SetInputSignal(_aiBrain);
                _aiBrainGO.SetActive(true);
                break;
        }
    }



}
