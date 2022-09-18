using System;
using UnityEngine;

public class ProductCard : MonoBehaviour
{
    [SerializeField] private Preview _preview;
    [SerializeField] private Product _product;
    [SerializeField] private float _price;

    public bool CanBuy(Wallet wallet)
    {
        return wallet.CanSpend(_price);
    }

    public Preview SpawnPreview()
    {
        return Instantiate(_preview);
    }

    public void ReturnPreview(Preview preview)
    {
        Destroy(preview);
    }

    public Product BuyProduct(Wallet wallet)
    {
        if (CanBuy(wallet) == false)
            throw new InvalidOperationException(nameof(CanBuy));

        wallet.Spend(_price);
        return Instantiate(_product);
    }
}
