using UnityEngine;
using UnityEngine.Events;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private PlayerInputSignalSO playerInputSignalSO;
    [SerializeField] private UnityEvent<float> _onRotate = new UnityEvent<float>();
    [SerializeField] private UnityEvent _onBoost = new UnityEvent();
    [SerializeField] private UnityEvent _onFire = new UnityEvent();

    private void OnEnable()
    {
        playerInputSignalSO.onRotateInputPress += OnRotateInput;
        playerInputSignalSO.onBoostInputPress += OnBoostInput;
        playerInputSignalSO.onFireInputPress += OnFireInput;
    }

    private void OnDisable()
    {
        playerInputSignalSO.onRotateInputPress -= OnRotateInput;
        playerInputSignalSO.onBoostInputPress -= OnBoostInput;
        playerInputSignalSO.onFireInputPress -= OnFireInput;
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
}
