using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotation : MonoBehaviour, IStopable
{
    [SerializeField] private float _rotationSpeed = 1.0f;
    [SerializeField] private Transform _targetTransform;
    private float _rotationDir = 0.0f;

    public void SetRotationDir(float rotationValue)
    {
        _rotationDir = rotationValue;
    }

    private void Update()
    {
        Rotate(Time.deltaTime);
    }

    private void Rotate(float deltaTime)
    {
        float rotationAmount = _rotationDir * _rotationSpeed * deltaTime;

        _targetTransform.Rotate(Vector3.forward, rotationAmount);
    }

    public void Stop()
    {
        _rotationDir = 0.0f;
    }
}
