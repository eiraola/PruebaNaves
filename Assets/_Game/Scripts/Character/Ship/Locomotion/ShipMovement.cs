using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMovement : MonoBehaviour, IStopable, IInitializable, IReseteable
{
    [SerializeField] private Transform _targetGO;
    [SerializeField] private float _speed = 1.0f;
    [Min(0.1f)]
    [SerializeField] private float _acceleratonTime = 1.0f;
    [Min(0.1f)]
    [SerializeField] private float _maxRotationBreakTime = 1.0f;
    [Range(0.1f, 0.9f )]
    [SerializeField] private float _maxRotationBreakValue = 0f;
    [SerializeField] private BoostSkill _boostSkill;
    [SerializeField] private ShipRotation rotationSkill;
    private float _rotationDecelAmount = 1.0f;
    private float _currentAccelerationTime = 0.0f;
    private float _accelerationValue = 0.0f;
    private Rigidbody2D _rigidBody = default;
    private bool _isStopped = true;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Accelerate(float deltaTime)
    {
        if (_isStopped) 
        {
            return;
        }
        _currentAccelerationTime = Mathf.Min(_currentAccelerationTime + deltaTime, _acceleratonTime);
        _accelerationValue = _currentAccelerationTime / _acceleratonTime;
    }

    private void RotationDeceleration()
    {
        if (rotationSkill.RotationTime > _maxRotationBreakTime)
        {
            _rotationDecelAmount = 1 - _maxRotationBreakValue;
            return;
        }

        _rotationDecelAmount = 1 - _maxRotationBreakValue * (rotationSkill.RotationTime / _maxRotationBreakTime);
    }

    private void Update()
    {
        Accelerate(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        RotationDeceleration();
        SetVelocity();
    }

    private void SetVelocity()
    {
        _rigidBody.velocity = -_targetGO.up * _accelerationValue * _rotationDecelAmount * (_speed + BoostVelocity());
    }

    private float BoostVelocity()
    {
        if (!_boostSkill)
        {
            return 0.0f;
        }

        return _boostSkill.CurrentBoostValue;
    }

    public void Stop()
    {
        _accelerationValue = 0.0f;
        _isStopped = true;
    }

    public void Initialize()
    {
        _isStopped = false;
    }

    public void Restart()
    {
        _targetGO.localRotation = Quaternion.identity;
    }
}
