using UnityEngine;

[CreateAssetMenu(fileName = "NewPoolSignal", menuName = "ScriptableObjects/System/Gameplay/Pool Signal", order = 1)]
public class BulletPoolSignalSO : ScriptableObject
{
    public BulletPool bulletPool;
    
    public void Pool(Bullet poolable)
    {
        bulletPool.Pool(poolable);
    }

    public Bullet Depool()
    {
        return bulletPool.Depool();
    }
}
