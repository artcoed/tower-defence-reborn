using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private EnemyDetector _enemyDetector;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _reloadSeconds;

    private float _elapsedReloadSeconds;

    private void Update()
    {
        _elapsedReloadSeconds += Time.deltaTime;
        if (_elapsedReloadSeconds >= _reloadSeconds && _enemyDetector.HasDetectedEnemy())
        {
            var targetEnemy = _enemyDetector.GetNearestEnemy();
            _elapsedReloadSeconds = 0;
            Instantiate(_bullet, transform.position, Quaternion.LookRotation(targetEnemy.transform.position));
        }
    }
}
