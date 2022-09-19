using System;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BoostCard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float _price;
    [SerializeField] private float _reloadSeconds;

    private float _elapsedReloadSeconds;
    private bool _clicking;

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

    protected abstract void OnBought();
}
