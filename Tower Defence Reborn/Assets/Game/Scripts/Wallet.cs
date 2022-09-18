using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private float _money;

    public void Earn(float money)
    {
        if (money < 0)
            throw new ArgumentOutOfRangeException(nameof(money));

        _money += money;
    }

    public bool CanSpend(float money)
    {
        if (money < 0)
            throw new ArgumentOutOfRangeException(nameof(money));

        return _money >= money;
    }

    public bool Spend(float money)
    {
        if (CanSpend(money) == false)
            throw new InvalidOperationException(nameof(Spend));

        return _money >= money;
    }
}
