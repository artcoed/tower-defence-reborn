using System.Collections.Generic;
using UnityEngine;

public class CrumblingEnemy : Enemy
{
    [SerializeField] private List<Enemy> _parts;
    
    public override float GetDamage()
    {
        var damage = 0f;

        foreach (var part in _parts)
        {
            damage += part.GetDamage();
        }

        return damage;
    }

    protected override void OnDead()
    {
        foreach (var part in _parts)
        {
            Instantiate(part, transform.position, transform.rotation);
        }
    }
}
