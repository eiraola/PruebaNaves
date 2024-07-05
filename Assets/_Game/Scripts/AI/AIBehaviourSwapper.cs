using System.Collections;
using UnityEngine;

public class AIBehaviourSwapper : MonoBehaviour
{
    [SerializeField] private AIBehaviourSwapperSignalSO _aiSignalSO;
    [SerializeField] private AIBehaviutChangeStatsSO _hardBehaviourStats;
    [SerializeField] private AIBehaviutChangeStatsSO _easyBehaviourStats;
    [SerializeField] private AILocomotion _aiLocomotionSystem;
    [SerializeField] private float _timeBetweenBehaviours = 10f;
    private AIBehaviutChangeStatsSO _currentBehaviourStats;
    private EBehaviourType _currentBehaviour = EBehaviourType.Passive;
    private Coroutine _swapBehaviourCoroutine = null;

    public EBehaviourType CurrentBehaviour { get => _currentBehaviour;}

    private void OnEnable()
    {
        _swapBehaviourCoroutine = StartCoroutine(CoSwapBehaviour());
        _aiSignalSO.onEasyModeSet += SetEasyMode;
        _aiSignalSO.onHardModeSet += SetHardMode;
    }

    private void OnDisable()
    {
        if (_swapBehaviourCoroutine != null)
        {
            StopCoroutine(_swapBehaviourCoroutine);
            _swapBehaviourCoroutine = null;
        }
        _aiSignalSO.onEasyModeSet -= SetEasyMode;
        _aiSignalSO.onHardModeSet -= SetHardMode;
    }

    public void SetHardMode()
    {
        _currentBehaviourStats = _hardBehaviourStats;
    }

    public void SetEasyMode()
    {
        _currentBehaviourStats = _easyBehaviourStats;
    }

    private void SelectNextBehaviour()
    {
        float maxStatValue = _currentBehaviourStats.PassiveBehaviourPercentaje
            + _currentBehaviourStats.AgressiveBehaviourPercentaje
            + _currentBehaviourStats.VeryAgressiveBehaviourPercentaje;

        float changeValue = Random.Range(0.0f, maxStatValue);

        if (changeValue < _currentBehaviourStats.PassiveBehaviourPercentaje)
        {
            _currentBehaviour = EBehaviourType.Passive;
        }
        else if (changeValue < _currentBehaviourStats.PassiveBehaviourPercentaje + _currentBehaviourStats.AgressiveBehaviourPercentaje)
        {
            _currentBehaviour = EBehaviourType.Agressive;
        }
        else
        {
            _currentBehaviour = EBehaviourType.VeryAgressive;
        }
    }


    #region Coroutines
    private IEnumerator CoSwapBehaviour()
    {
        while (true) 
        { 
            yield return new WaitForSeconds(_timeBetweenBehaviours);
            SelectNextBehaviour();
            _aiLocomotionSystem.BehaviourType = _currentBehaviour;
        }
    }


    #endregion
}
