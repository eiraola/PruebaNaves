using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotation : MonoBehaviour, IStopable, IReseteable
{
    [SerializeField] private float _rotationSpeed = 1.0f;
    [SerializeField] private Transform _targetTransform;
    private float _rotationDir = 0.0f;
    private float _rotationTime = 0.0f;
    private bool _isStopped = true;

    public float RotationTime { get => _rotationTime;}

    public void SetRotationDir(float rotationValue)
    {
        if (_isStopped)
        {
            return;
        }
        _rotationDir = rotationValue;
    }

    private void Update()
    {
        Rotate(Time.deltaTime);
        RecordRotationTime(Time.deltaTime);
    }

    private void Rotate(float deltaTime)
    {
        float rotationAmount = _rotationDir * _rotationSpeed * deltaTime;

        _targetTransform.Rotate(Vector3.forward, rotationAmount);
    }

    public void RecordRotationTime(float deltaTime)
    {
        if (_rotationDir == 0.0f)
        {
            _rotationTime = 0.0f;
            return;
        }
        _rotationTime += deltaTime;
    }

    public void Stop()
    {
        _rotationDir = 0.0f;
        _isStopped = true;
    }

    public void Restart()
    {
        _isStopped = false;
    }
}
