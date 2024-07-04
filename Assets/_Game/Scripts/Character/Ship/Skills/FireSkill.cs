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
    [SerializeField] private float _timeBetweenShoots = 0.5f;
    [SerializeField] private SoundSignalSO _soundSignalSO;
    private float _lastTimeShoot = 0.0f;
    private Rigidbody2D _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private float GetRBVel()
    {
        if (_rigidBody == null)
        { 
            return 0.0f;
        }
        return _rigidBody.velocity.magnitude;
    }
    public void Fire()
    {
        if (Time.time < _lastTimeShoot + _timeBetweenShoots)
        {
            return;
        }
        _lastTimeShoot = Time.time;
        Bullet bullet = _bulletPoolSO.Depool();
        bullet.transform.position = _firePos.position;
        bullet.transform.rotation = _firePos.rotation;
        bullet.SetTeam(_team.TeamID);
        bullet.SetDamage(_bulletDamage);
        bullet.SetSpeed(_bulletSpeed + GetRBVel());
        bullet.gameObject.SetActive(true);
        PlayFireSound();
    }
    
    private void PlayFireSound()
    {
        if (!_soundSignalSO) 
        {
            return;
        }
        _soundSignalSO.PlayClipSound(EClip.Shoot);
    }

    private ETeam GetTeam()
    {
        if (!_team)
        {
            return 0;
        }

        return _team.TeamID;
    }
}
