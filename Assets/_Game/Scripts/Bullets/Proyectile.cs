using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Proyectile : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    private Rigidbody2D _rigidbody;

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = -transform.up * _speed;
    }
}
