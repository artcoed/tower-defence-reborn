using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Enemy>(out var enemy) && enemy.Dead() == false)
        {
            enemy.Die();
        }
    }
}
