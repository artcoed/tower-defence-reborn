using UnityEngine;

public class DefaultEnemy : Enemy
{
    [SerializeField] private float _damage;

    public override float GetDamage()
    {
        return _damage;
    }
}
