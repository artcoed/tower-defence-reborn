using System;
using UnityEngine;

public class Product : MonoBehaviour
{
    [SerializeField] private float _price;

    [field: SerializeField] public Product FirstUpgrade { get; private set; }
    [field: SerializeField] public Product SecondUpgrade { get; private set; }

    public void Place(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

    public void RaisePrice(float price)
    {
        if (price < 0)
            throw new ArgumentOutOfRangeException(nameof(RaisePrice));

        _price += price;
    }

    public float GetPrice()
    {
        return _price;
    }

    public bool HasFirstUpgrade()
    {
        return FirstUpgrade != null;
    }

    public bool HasSecondUpgrade()
    {
        return SecondUpgrade != null;
    }
}
