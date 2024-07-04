using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindUI : MonoBehaviour
{
    private const float NAIL_UP_DIR = 0.0f;
    private const float NAIL_RIGHT_DIR = -90.0f;
    private const float NAIL_LEFT_DIR = 90.0f;
    private const float NAIL_DOWN_DIR = 180.0f;

    [SerializeField] private GameObject _compassNail;
    [SerializeField] private WindDirectionSignalSenderSO _windDirectionSignalSender;
    private Quaternion _targetRotation = Quaternion.identity;

    private void OnEnable()
    {
        _windDirectionSignalSender.onWindChange += ChangeNailDir;
    }

    private void OnDisable()
    {
        _windDirectionSignalSender.onWindChange -= ChangeNailDir;
    }

    public void ChangeNailDir(EWindDirection direction)
    {
        switch (direction)
        {
            case EWindDirection.Up:
                _compassNail.transform.rotation = Quaternion.Euler(0.0f, 0.0f, NAIL_UP_DIR);
                break;
            case EWindDirection.Down:
                _compassNail.transform.rotation = Quaternion.Euler(0.0f, 0.0f, NAIL_DOWN_DIR);
                break;
            case EWindDirection.Left:
                _compassNail.transform.rotation = Quaternion.Euler(0.0f, 0.0f, NAIL_LEFT_DIR);
                break;
            case EWindDirection.Right:
                _compassNail.transform.rotation = Quaternion.Euler(0.0f, 0.0f, NAIL_RIGHT_DIR);
                break;
            default:
                break;
        }
    }
}
