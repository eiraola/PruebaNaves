using UnityEngine;
using UnityEngine.Events;

public class LifeSystem : MonoBehaviour, IDamageable, IReseteable
{

    [SerializeField] private int _maxHP = 100;
    [SerializeField] private Team _team;
    [SerializeField] private LifeSystemSignalSO _lifeSystemSignalSO;
    [SerializeField] private SoundSignalSO _soundSignalSO;
    [SerializeField] private UnityEvent _onZeroHPReached = new UnityEvent();

    private float _currentHP = 0;

    public ETeam GetTeamID()
    {
        if (!_team)
        {
            return 0;
        }

        return _team.TeamID;
    }

   

    public void RecieveDamage(int damage)
    {
        if (_currentHP <= 0)
        {
            return;
        }

        _currentHP = Mathf.Max(0, _currentHP - damage);
        _lifeSystemSignalSO.LifeChanged(_currentHP / _maxHP);
        PlayDamageSound();
        if (_currentHP <= 0)
        {
            ZeroLifeReached();
        }

    }

    public void Restart()
    {
        _currentHP = _maxHP;
        _lifeSystemSignalSO.LifeChanged(_currentHP / _maxHP);
    }

    public void ZeroLifeReached()
    {
        _onZeroHPReached?.Invoke();
    }

    private void Start()
    {
        _currentHP = _maxHP;
        _lifeSystemSignalSO.LifeChanged(_currentHP / _maxHP);
    }

    private void PlayDamageSound()
    {
        if (!_soundSignalSO)
        {
            return;
        }

        _soundSignalSO.PlayClipSound(EClip.Impact);
    }
}
