using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour, IStopable
{
    [SerializeField] private int _initialCapacity = 10;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private BulletPoolSignalSO _poolSignalSO;
    private Queue<Bullet> _bullets = new Queue<Bullet>();
    private List<Bullet> _depooledBullets = new List<Bullet>();

    void Start()
    {
        for (int i = 0; i < _initialCapacity; i++)
        {
            _bullets.Enqueue(Instantiate(_bulletPrefab));
        }

        _poolSignalSO.bulletPool = this;
    }

    public Bullet Depool() 
    {
        Bullet poolable;

        if (_bullets.Count == 0) {
            poolable = Instantiate(_bulletPrefab); 
        }
        else 
        {
            poolable = _bullets.Dequeue();
        }
    
        poolable.Depool();
        _depooledBullets.Add(poolable);

        return poolable;
    }

    public void Pool(Bullet poolableElement) 
    {
        _depooledBullets.Remove(poolableElement);
        _bullets.Enqueue(poolableElement);
        poolableElement.transform.parent = transform;
        poolableElement.transform.localPosition = Vector3.zero;
    }

    public void Stop()
    {
        List<Bullet> _depooledBulletsAux = new List<Bullet>(_depooledBullets);
        foreach (Bullet bullet in _depooledBulletsAux)
        {
            bullet.Pool();
        }
    }
}
