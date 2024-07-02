using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMovement : MonoBehaviour
{
    [SerializeField] private Transform _targetGO;
    [SerializeField] private float _speed;
    [SerializeField] private BoostSignalSO _boostSignal;
    private Rigidbody2D _rigidBody = default;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
       
    }
    private void Update()
    {
        SetVelocity();
    }

    private void SetVelocity()
    {
        _rigidBody.velocity = -_targetGO.up * (_speed + BoostVelocity());
    }

    private float BoostVelocity()
    {
        if (!_boostSignal)
        {
            return 0.0f;
        }

        return _boostSignal.BoostVelocity;
    }
}
