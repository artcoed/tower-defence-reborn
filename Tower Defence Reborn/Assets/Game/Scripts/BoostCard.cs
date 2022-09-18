using System;
using UnityEngine;

public abstract class BoostCard : MonoBehaviour
{
    [SerializeField] private float _price;
    [SerializeField] private float _reloadSeconds;

    private float _elapsedReloadSeconds;

    private void Update()
    {
        _elapsedReloadSeconds += Time.deltaTime;
    }

    public bool CanBuy(Wallet wallet)
    {
        return wallet.CanSpend(_price) && _elapsedReloadSeconds >= _reloadSeconds;
    }

    public void Buy(Wallet wallet)
    {
        if (CanBuy(wallet) == false)
            throw new InvalidOperationException(nameof(CanBuy));

        _elapsedReloadSeconds = 0;
        wallet.Spend(_price);
        OnBought();
    }

    protected abstract void OnBought();
}
