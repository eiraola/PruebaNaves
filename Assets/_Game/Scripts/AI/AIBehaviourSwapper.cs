using System.Collections;
using UnityEngine;

public class AIBehaviourSwapper : MonoBehaviour
{
    [SerializeField] float _timeBetweenBehaviours = 10f;
    private EBehaviourType _currentBehaviour = EBehaviourType.Passive;
    private Coroutine _swapBehaviourCoroutine = null;

    public EBehaviourType CurrentBehaviour { get => _currentBehaviour;}

    private void OnEnable()
    {
        _swapBehaviourCoroutine = StartCoroutine(CoSwapBehaviour());
    }

    private void OnDisable()
    {
        if (_swapBehaviourCoroutine != null)
        {
            StopCoroutine(_swapBehaviourCoroutine);
            _swapBehaviourCoroutine = null;
        }
    }

    #region Coroutines
    private IEnumerator CoSwapBehaviour()
    {
        while (true) 
        { 
            yield return new WaitForSeconds( _timeBetweenBehaviours );

            switch (_currentBehaviour)
            {
                case EBehaviourType.Passive:
                    _currentBehaviour = EBehaviourType.Agressive;
                    break;
                case EBehaviourType.Agressive:
                    _currentBehaviour = EBehaviourType.VeryAgressive;
                    break;
                case EBehaviourType.VeryAgressive:
                    _currentBehaviour = EBehaviourType.VeryAgressive;
                    break;
                default:
                    _currentBehaviour = EBehaviourType.Agressive;
                    break;
            }
        }
    }
    #endregion
}
