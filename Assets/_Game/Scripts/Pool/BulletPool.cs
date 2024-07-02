using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private int _initialCapacity = 10;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private BulletPoolSignalSO _poolSignalSO;
    private Queue<Bullet> _bullets = new Queue<Bullet>();

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

        return poolable;
    }

    public void Pool(Bullet poolableElement) 
    {
        _bullets.Enqueue(poolableElement);
    }
}
