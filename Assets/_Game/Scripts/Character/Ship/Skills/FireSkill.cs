using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkill : MonoBehaviour
{
    [SerializeField] private BulletPoolSignalSO _bulletPoolSO;
    [SerializeField] private Transform _firePos;

    public void Fire()
    {
        Bullet bullet = _bulletPoolSO.Depool();
        bullet.transform.position = _firePos.position;
        bullet.transform.rotation = _firePos.rotation;
        bullet.gameObject.SetActive(true);
    }
}
