using UnityEngine;
using UnityEngine.EventSystems;

public class ProductUIInput : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    private bool _clicking;

    public bool Clicking()
    {
        return _clicking;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _clicking = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _clicking = false;
    }
}
