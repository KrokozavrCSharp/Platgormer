using UnityEngine;

public class Wallet : MonoBehaviour
{
    private float _countMoney = 0;

    public void MoneyIncrease(Coin coin)
    {
        _countMoney += coin.GetCost();
    }
}
