using System;
using TMPro;
using UnityEngine;

public class ProductUI : MonoBehaviour
{
    [SerializeField] private ProductUIInput _productUIInput;
    [SerializeField] private ProductSellInput _productSellInput;
    [SerializeField] private ProductUpgrade _firstUpgrade;
    [SerializeField] private ProductUpgrade _secondUpgrade;
    [SerializeField] private TMP_Text _sellPriceText;

    private bool _showed;

    public bool Showed()
    {
        return _showed;
    }

    public void Show(Product product)
    {
        if (Showed())
            throw new InvalidOperationException(nameof(Show));

        _showed = true;

        if (product.HasFirstUpgrade())
            _firstUpgrade.Show(product.GetFirstUpgrade());
        else
            _firstUpgrade.Lock(product.Sprite);

        if (product.HasSecondUpgrade())
            _secondUpgrade.Show(product.GetSecondUpgrade());
        else
            _secondUpgrade.Lock(product.Sprite);

        _sellPriceText.text = product.GetSellPrice().ToString();

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        if (Showed() == false)
            throw new InvalidOperationException(nameof(Hide));

        _showed = false;
        gameObject.SetActive(false);
    }

    public bool Clicking()
    {
        return _productUIInput.Clicking() || _productSellInput.Selling();
    }

    public bool Selling()
    {
        return _productSellInput.Selling();
    }
}
