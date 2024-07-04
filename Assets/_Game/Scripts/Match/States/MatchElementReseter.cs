using UnityEngine;

public class MatchElementReseter : MonoBehaviour
{
    [SerializeField] MatchStateChangeSO _matchStateChanger;
    private IReseteable[] _reseteables;
    private IInitializable[] _initializables;
    private IStopable[] _stopables;
    private Vector3 _initialPosition = Vector3.zero;
    private Quaternion _initialRotation = Quaternion.identity;

    private void Start()
    {
        _initialPosition = transform.position;
        _initialRotation = transform.rotation;
        _reseteables = GetComponentsInChildren<IReseteable>();
        _initializables = GetComponentsInChildren<IInitializable>();
        _stopables = GetComponentsInChildren<IStopable>();
    }

    private void OnEnable()
    {
        _matchStateChanger.onGameInit += InitializeElements;
        _matchStateChanger.onGameRestart += ResetElements;
        _matchStateChanger.onGameStop += StopElements;
    }

    private void OnDisable()
    {
        _matchStateChanger.onGameInit -= InitializeElements;
        _matchStateChanger.onGameRestart -= ResetElements;
        _matchStateChanger.onGameStop -= StopElements;
    }

    private void StopElements()
    {
        for (int i = 0; i < _stopables.Length; i++)
        {
            _stopables[i].Stop();
        }
    }

    private void ResetElements()
    {
        transform.position = _initialPosition;
        transform.rotation = _initialRotation;
        for (int i = 0; i < _reseteables.Length; i++)
        {
            _reseteables[i].Restart();
        }
    }

    private void InitializeElements()
    {
        for (int i = 0; i < _initializables.Length; i++)
        {
            _initializables[i].Initialize();
        }
    }
}
