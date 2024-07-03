using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkill : MonoBehaviour
{
    [SerializeField] private BulletPoolSignalSO _bulletPoolSO;
    [SerializeField] private Transform _firePos;
    [SerializeField] private Team _team;
    [SerializeField] private int _bulletDamage = 10;
    [SerializeField] private float _bulletSpeed = 3;

    public void Fire()
    {
        Bullet bullet = _bulletPoolSO.Depool();
        bullet.transform.position = _firePos.position;
        bullet.transform.rotation = _firePos.rotation;
        bullet.SetTeam(_team.TeamID);
        bullet.SetDamage(_bulletDamage);
        bullet.SetSpeed(_bulletSpeed);
        bullet.gameObject.SetActive(true);
    }

    private int GetTeam()
    {
        if (!_team)
        {
            return 0;
        }

        return _team.TeamID;
    }
}
