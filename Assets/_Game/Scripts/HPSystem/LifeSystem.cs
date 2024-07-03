using UnityEngine;
using UnityEngine.Events;

public class LifeSystem : MonoBehaviour, IDamageable
{

    [SerializeField] private int _maxHP = 100;
    [SerializeField] private Team _team;
    [SerializeField] private LifeSystemSignalSO _lifeSystemSignalSO;
    [SerializeField] private UnityEvent _onZeroHPReached = new UnityEvent();

    private float _currentHP = 0;

    public int GetTeamID()
    {
        if (!_team)
        {
            return 0;
        }

        return _team.TeamID;
    }

   

    public void RecieveDamage(int damage)
    {
        _currentHP = Mathf.Max(0, _currentHP - damage);
        _lifeSystemSignalSO.LifeChanged(_currentHP / _maxHP);

        if (_currentHP <= 0)
        {
            ZeroLifeReached();
        }

    }

    public void ZeroLifeReached()
    {
        _onZeroHPReached?.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentHP = _maxHP;
    }
}
