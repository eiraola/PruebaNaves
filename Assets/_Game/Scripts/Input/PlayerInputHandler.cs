using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> _onRotate = new UnityEvent<float>();
    [SerializeField] private UnityEvent _onBoost = new UnityEvent();
    [SerializeField] private UnityEvent _onFire = new UnityEvent();


    public void OnRotateInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _onRotate?.Invoke(context.ReadValue<float>());
        }

        if (context.canceled)
        {
            _onRotate?.Invoke(context.ReadValue<float>());
        }
    }

    public void OnBoostInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _onBoost?.Invoke();
        }
    }

    public void OnFireInput(InputAction.CallbackContext context) 
    {
        if (context.performed)
        {
            _onFire?.Invoke();
        }
    }
}
