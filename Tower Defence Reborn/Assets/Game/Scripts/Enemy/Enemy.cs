using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    [SerializeField] private Road _road;
    [SerializeField] private float _moveSpeed;

    private bool _dead;
    private float _moveProgress;

    private void Update()
    {
        if (_dead)
            return;

        _moveProgress = Mathf.Max(_moveSpeed * Time.deltaTime, 1f);
        transform.position = _road.GetPosition(_moveProgress);

        if (_moveProgress == 1f)
        {
            _tower.TakeDamage(GetDamage());
            Die();
        }
    }

    public abstract float GetDamage();

    public bool Dead()
    {
        return _dead;
    }

    public void Die()
    {
        if (Dead())
            throw new InvalidOperationException(nameof(Die));

        _dead = true;

        Destroy(gameObject);
        OnDead();
    }

    public float GetMoveProgress()
    {
        return _moveProgress;
    }

    protected virtual void OnDead() { }
}
