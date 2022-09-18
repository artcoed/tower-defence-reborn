using UnityEngine;

public class Preview : MonoBehaviour
{
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
        return true;
    }
}
