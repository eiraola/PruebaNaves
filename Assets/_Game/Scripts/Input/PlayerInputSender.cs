using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSender : MonoBehaviour
{
    [SerializeField] private PlayerInputSignalSO _playerInputSignal;

    public void SendRotationInput(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            _playerInputSignal.RotationInputPress(context.ReadValue<float>());
        }
    }

    public void SendBoostInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _playerInputSignal.BoostInputPress();
        }
    }

    public void SendFireInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _playerInputSignal.FireInputPress();
        }
    }
}
