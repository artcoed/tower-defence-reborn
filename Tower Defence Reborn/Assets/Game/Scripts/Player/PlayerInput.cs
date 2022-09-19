using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool Pressing()
    {
        return Input.GetMouseButton(0);
    }

    public Vector3 GetPosition()
    {
        return Input.mousePosition;
    }
}
