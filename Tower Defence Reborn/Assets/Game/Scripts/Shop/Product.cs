using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Product : MonoBehaviour
{
    [SerializeField] private Product _firstUpgrade;
    [SerializeField] private Product _secondUpgrade;
    [SerializeField] private float _price;
    [SerializeField] private float _sellPrice;

    [field: SerializeField] public Sprite Sprite { get; private set; }

    public void Place(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

    public float GetPrice()
    {
        return _price;
    }

    public float GetSellPrice()
    {
        return _sellPrice;
    }

    public bool HasFirstUpgrade()
    {
        return _firstUpgrade != null;
    }

    public Product GetFirstUpgrade()
    {
        if (HasFirstUpgrade() == false)
            throw new InvalidOperationException(nameof(GetFirstUpgrade));

        return _firstUpgrade;
    }

    public bool HasSecondUpgrade()
    {
        return _secondUpgrade != null;
    }

    public Product GetSecondUpgrade()
    {
        if (HasSecondUpgrade() == false)
            throw new InvalidOperationException(nameof(GetSecondUpgrade));

        return _secondUpgrade;
    }
}
