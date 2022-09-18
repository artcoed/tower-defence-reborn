using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    private List<Enemy> _detectedEnemies;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Enemy>(out var enemy))
        {
            _detectedEnemies.Add(enemy);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<Enemy>(out var enemy))
        {
            _detectedEnemies.Remove(enemy);
        }
    }

    public bool HasDetectedEnemy()
    {
        ClearDeadEnemies();
        return _detectedEnemies.Count > 0;
    }

    public Enemy GetNearestEnemy()
    {
        if (HasDetectedEnemy() == false)
            throw new InvalidOperationException(nameof(GetNearestEnemy));

        var nearestProgress = 0f;
        var nearestEnemy = _detectedEnemies[0];

        foreach (var enemy in _detectedEnemies)
        {
            var progress = enemy.GetMoveProgress();
            if (progress >= nearestProgress)
            {
                nearestProgress = progress;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    private void ClearDeadEnemies()
    {
        for (var i = 0; i < _detectedEnemies.Count; i++)
        {
            var enemy = _detectedEnemies[i];
            if (enemy.Dead())
            {
                var lastIndex = _detectedEnemies.Count - 1;
                _detectedEnemies[i] = _detectedEnemies[lastIndex];
                _detectedEnemies.RemoveAt(lastIndex);
            }
        }
    }
}
