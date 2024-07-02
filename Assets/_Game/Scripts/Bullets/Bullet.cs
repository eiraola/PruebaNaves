using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IPoolable
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _lifeTime = 3.0f;
    [SerializeField] private BulletPoolSignalSO _signalSO;
    private Rigidbody2D _rigidbody;
    private Coroutine _lifeTimeCoroutine = null;

    public void Depool()
    {
        
    }

    public void Pool()
    {
        if (_lifeTimeCoroutine != null)
        {
            StopCoroutine(_lifeTimeCoroutine);
            _lifeTimeCoroutine = null;
        }
        _signalSO.Pool(this);
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _lifeTimeCoroutine = StartCoroutine(CoDestroyByTime());
    }

    void FixedUpdate()
    {
        _rigidbody.velocity = -transform.up * _speed;
    }
    #region Coroutines
    private IEnumerator CoDestroyByTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        _lifeTimeCoroutine = null;
        Pool();
       
    }

    #endregion
}
