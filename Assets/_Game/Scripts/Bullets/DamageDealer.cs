using UnityEngine;
using UnityEngine.Events;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private VFXSignalSenderSO _vfxSignalSender;
    [SerializeField] private UnityEvent _onDamageDone = new UnityEvent();
    private ETeam _team = 0;
    private int _damage = 0;

    public ETeam Team { get => _team; }

    public void SetTeam(ETeam team) 
    {  
        _team = team; 
    }

    public void SetDamage(int damage) 
    {
        _damage = damage;
    }

    private void PlayDamageVFX()
    {
        if (!_vfxSignalSender)
        {
            return;
        }

        _vfxSignalSender.PlayVFX(_team, transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable damageable) && damageable.GetTeamID() != _team)
        {
            damageable.RecieveDamage(_damage);
            PlayDamageVFX();
            _onDamageDone?.Invoke();
        }
    }
}
