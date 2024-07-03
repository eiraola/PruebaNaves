using UnityEngine;
using UnityEngine.Events;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private UnityEvent _onDamageDone = new UnityEvent();
    private int _team = 0;
    private int _damage = 0;

    public void SetTeam(int team) 
    {  
        _team = team; 
    }

    public void SetDamage(int damage) 
    {
        _damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable damageable) && damageable.GetTeamID() != _team)
        {
            damageable.RecieveDamage(_damage);
            _onDamageDone?.Invoke();
        }
    }
}
