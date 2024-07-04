using UnityEngine;
using UnityEngine.Events;

public class PlayerInputHandler : MonoBehaviour, IStopable, IInitializable
{
    [SerializeField] private PlayerInputSignalSO _playerInputSignalSO;
    [SerializeField] private UnityEvent<float> _onRotate = new UnityEvent<float>();
    [SerializeField] private UnityEvent _onBoost = new UnityEvent();
    [SerializeField] private UnityEvent _onFire = new UnityEvent();

    private void OnEnable()
    {
        _playerInputSignalSO.onRotateInputPress += OnRotateInput;
        _playerInputSignalSO.onBoostInputPress += OnBoostInput;
        _playerInputSignalSO.onFireInputPress += OnFireInput;
    }

    private void OnDisable()
    {
        _playerInputSignalSO.onRotateInputPress -= OnRotateInput;
        _playerInputSignalSO.onBoostInputPress -= OnBoostInput;
        _playerInputSignalSO.onFireInputPress -= OnFireInput;
    }

    public void SetInputSignal(PlayerInputSignalSO newInputSignal)
    {
        _playerInputSignalSO = newInputSignal;
    }

    public void OnRotateInput(float inputValue)
    {
        _onRotate?.Invoke(inputValue);
    }

    public void OnBoostInput()
    {
        _onBoost?.Invoke();
    }

    public void OnFireInput() 
    {
        _onFire?.Invoke();
    }

    public void Stop()
    {
       this.enabled = false;
    }

    public void Initialize()
    {
        this.enabled = true;
    }
}
