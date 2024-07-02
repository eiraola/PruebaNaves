using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPositionCorrector : MonoBehaviour
{
    private Vector2 _screenBounds = Vector2.zero;
    private Vector3 _currentPos = Vector3.zero;

    private void Start()
    {
        Camera mainCamera = Camera.main;
        _screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        //objectWidth = GetComponent<SpriteRenderer>().bounds.extents.x; // Extents = size of half the object
        //objectHeight = GetComponent<SpriteRenderer>().bounds.extents.y;
    }
    private void Update()
    {
        CalculateBounds();
    }

    private void CalculateBounds()
    {
        _currentPos = transform.position;

        if (_currentPos.x > _screenBounds.x)
        {
            _currentPos.x = -_screenBounds.x;
        }

        if (_currentPos.x < -_screenBounds.x)
        {
            _currentPos.x = _screenBounds.x;
        }

        if (_currentPos.y > _screenBounds.y)
        {
            _currentPos.y = -_screenBounds.y;
        }

        if (_currentPos.y < -_screenBounds.y)
        {
            _currentPos.y = _screenBounds.y;
        }

        transform.position = _currentPos;
    }
}
