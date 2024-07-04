using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMovement : MonoBehaviour, IStopable, IInitializable
{
    [SerializeField] private Transform _targetGO;
    [SerializeField] private float _speed;
    [SerializeField] private BoostSkill _boostSkill;
    private float _accelerationValue = 0.0f;
    private Rigidbody2D _rigidBody = default;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _accelerationValue = 1.0f;


    }
    private void Update()
    {
        SetVelocity();
    }

    private void SetVelocity()
    {
        _rigidBody.velocity = -_targetGO.up * _accelerationValue * (_speed + BoostVelocity());
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
    }

    public void Initialize()
    {
        _accelerationValue = 1.0f;
    }
}
