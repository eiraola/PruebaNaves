using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
    
    [SerializeField] private float _lifeTime = 3.0f;
    [SerializeField] private BulletPoolSignalSO _signalSO;
    [SerializeField] private Proyectile _proyectile;
    [SerializeField] private DamageDealer _damageDealer;
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

    private void OnEnable()
    {
        _lifeTimeCoroutine = StartCoroutine(CoDestroyByTime());
    }

    public void SetTeam(int team)
    {
        if (!_damageDealer)
        {
            return;
        }

        _damageDealer.SetTeam(team);
    }

    public void SetDamage(int damage)
    {
        if (!_damageDealer)
        {
            return;
        }

        _damageDealer.SetDamage(damage);
    }

    public void SetSpeed(float speed)
    {
        if (!_proyectile)
        {
            return;
        }
        _proyectile.SetSpeed(speed);
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
