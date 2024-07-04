using UnityEngine;

public class WindDirectionReactor : MonoBehaviour
{
    [SerializeField] private WindDirectionSignalSenderSO _windDirectionSignalSO;
    [SerializeField] private Transform _referenceTransform;
    [SerializeField] private float _maxRotationForce = 20.0f;
    [SerializeField] private float _maxRotationReachTime = 2.0f;
    private float _currentRotationTime = 0;
    private float _currentRotationForce = 0.0f;
    private float _rotationDirection;
    

    private void OnEnable()
    {
        _currentRotationForce = 0.0f;
    }

    private void Update()
    {
        CurrentRotationMomentum(Time.deltaTime);
        CalculateRotationDir();
        RotateToWindDir(Time.deltaTime);
    }

    private void CalculateRotationDir()
    {
        _rotationDirection = Vector2.Dot(
           _referenceTransform.right,
           _windDirectionSignalSO.CurrentWindDirectionValue
           );
    }



    private void RotateToWindDir(float deltaTime)
    {
        float rotationAmount = _rotationDirection * _maxRotationForce * _currentRotationForce * deltaTime;
        _referenceTransform.Rotate(Vector3.forward, rotationAmount);
    }

    private void CurrentRotationMomentum(float deltaTime)
    {
        _currentRotationTime = Mathf.Min(_currentRotationTime + deltaTime, _maxRotationReachTime); 
        _currentRotationForce = _currentRotationTime/_maxRotationReachTime;
    }
}
