using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool Buying()
    {
        return Input.GetMouseButton(0);
    }

    public bool Browsing()
    {
        return Input.GetMouseButton(0);
    }

    public Vector3 GetBuyPosition()
    {
        return Input.mousePosition;
    }
}
