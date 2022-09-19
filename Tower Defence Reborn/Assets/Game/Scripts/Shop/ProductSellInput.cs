using UnityEngine;
using UnityEngine.EventSystems;

public class ProductSellInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool _selling;

    public bool Selling()
    {
        return _selling;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _selling = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _selling = false;
    }
}
