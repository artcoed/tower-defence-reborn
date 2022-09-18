using UnityEngine;

public class PermanentRotation : MonoBehaviour
{
    [SerializeField] private Vector3 _speed;

    private void Update()
    {
        transform.rotation *= Quaternion.Euler(_speed * Time.deltaTime);
    }
}
