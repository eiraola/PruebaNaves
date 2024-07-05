using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
    const string ANIM_DISSAPEAR = "Dissapear";
    const string ANIM_TRAVEL = "Travel";

    [SerializeField] private float _lifeTime = 3.0f;
    [SerializeField] private BulletPoolSignalSO _signalSO;
    [SerializeField] private Proyectile _proyectile;
    [SerializeField] private DamageDealer _damageDealer;
    [SerializeField] private TrailRenderer _trailRenderer;
    [SerializeField] private Animator _playerOneFireballAnimator;
    [SerializeField] private Animator _playerTwoFireballAnimator;
    private Coroutine _lifeTimeCoroutine = null;
    

    public void Depool()
    {
        transform.parent = null;
        _trailRenderer.enabled = true;
        _trailRenderer.emitting = true;
        _playerOneFireballAnimator.Play(ANIM_TRAVEL);
        _playerTwoFireballAnimator.Play(ANIM_TRAVEL);
    }

    public void Pool()
    {
        if (_lifeTimeCoroutine != null)
        {
            StopCoroutine(_lifeTimeCoroutine);
            _lifeTimeCoroutine = null;
        }
        
        _signalSO.Pool(this);
        _trailRenderer.enabled = false;
        _trailRenderer.emitting = false;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _lifeTimeCoroutine = StartCoroutine(CoDestroyByTime());
    }

    public void SetTeam(ETeam team)
    {
        if (!_damageDealer)
        {
            return;
        }
        ActivateTeamProyectile(team);
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

    public void PlayAnimDissapear()
    {
        _playerOneFireballAnimator.Play(ANIM_DISSAPEAR);
        _playerTwoFireballAnimator.Play(ANIM_DISSAPEAR);
    }

    private void ActivateTeamProyectile(ETeam team)
    {
        _playerOneFireballAnimator.gameObject.SetActive(team == ETeam.TeamOne);
        _playerTwoFireballAnimator.gameObject.SetActive(team == ETeam.TeamTwo);
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
