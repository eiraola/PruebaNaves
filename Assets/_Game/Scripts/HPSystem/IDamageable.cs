using UnityEngine;

public interface IDamageable 
{
    public void RecieveDamage(int damage);

    public void ZeroLifeReached();

    public ETeam GetTeamID();
}
