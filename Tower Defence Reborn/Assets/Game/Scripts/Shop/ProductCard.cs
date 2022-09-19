using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ProductCard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Preview _preview;
    [SerializeField] private Product _product;

    private bool _clicking;

    public bool CanBuy(Wallet wallet)
    {
        return wallet.CanSpend(_product.GetPrice());
    }

    public Preview SpawnPreview()
    {
        return Instantiate(_preview);
    }

    public void ReturnPreview(Preview preview)
    {
        Destroy(preview.gameObject);
    }

    public Product BuyProduct(Wallet wallet)
    {
        if (CanBuy(wallet) == false)
            throw new InvalidOperationException(nameof(CanBuy));

        wallet.Spend(_product.GetPrice());
        return Instantiate(_product);
    }

    public bool Clicking()
    {
        return _clicking;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _clicking = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _clicking = false;
    }
}
