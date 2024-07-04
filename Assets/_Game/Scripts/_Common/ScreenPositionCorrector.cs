using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScreenPositionCorrector : MonoBehaviour
{
    [SerializeField] private TrailRenderer _trailRenderer;
    private Vector2 _screenBounds = Vector2.zero;
    private Vector3 _currentPos = Vector3.zero;

    private void Start()
    {
        Camera mainCamera = Camera.main;
        _screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }
    private void Update()
    {
        CalculateBounds();
    }
    private float CalculateOpossitePosition(float screenCoordVal, float elementCoordVal) 
    { 
        float absScreenVal = Mathf.Abs(screenCoordVal * 2);
        float elementScreenVal = Mathf.Abs(elementCoordVal + screenCoordVal);
        float percentVal = 1.0f - Mathf.InverseLerp(0.0f, absScreenVal, elementScreenVal);
        return (percentVal * absScreenVal) - screenCoordVal;
    }

    private void CalculateBounds()
    {
        _currentPos = transform.position;

        if (_currentPos.x > _screenBounds.x)
        {
            _currentPos.x = -_screenBounds.x;
            _currentPos.y = CalculateOpossitePosition(_screenBounds.y, _currentPos.y);
        }

        if (_currentPos.x < -_screenBounds.x)
        {
            _currentPos.x = _screenBounds.x;
            _currentPos.y = CalculateOpossitePosition(_screenBounds.y, _currentPos.y);
        }

        if (_currentPos.y > _screenBounds.y)
        {
            _currentPos.y = -_screenBounds.y;
            _currentPos.x = CalculateOpossitePosition(_screenBounds.x, _currentPos.x);
        }

        if (_currentPos.y < -_screenBounds.y)
        {
            _currentPos.y = _screenBounds.y;
            _currentPos.x = CalculateOpossitePosition(_screenBounds.x, _currentPos.x);
        }
        if (_currentPos != transform.position)
        {
            StopEmitting();
        }
        transform.position = _currentPos;

        StartEmitting();
    }

    private void StopEmitting()
    {
        if (!_trailRenderer)
        {
            return;
        }

        _trailRenderer.Clear();
        _trailRenderer.enabled = false;
        _trailRenderer.emitting = false;
    }

    private void StartEmitting()
    {
        if (!_trailRenderer)
        {
            return;
        }
        _trailRenderer.enabled = true;
        _trailRenderer.emitting = true;
    }
}
