using UnityEngine;

public class Preview : MonoBehaviour
{
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private LayerMask _productMask;

    public void Show(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

    public void Move(Vector3 position)
    {
        transform.position = position;
    }

    public bool HasCrossed()
    {
        return Physics.CheckBox(transform.position + _boxCollider.center, _boxCollider.size / 2, transform.rotation, _productMask);
    }
}
