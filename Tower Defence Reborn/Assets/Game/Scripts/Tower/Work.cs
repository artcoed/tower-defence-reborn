using UnityEngine;

public class Work : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private float _income;
    [SerializeField] private float _incomeSeconds;
    [SerializeField] private float _accelerateIncomeSeconds;
    [SerializeField] private float _raiseIncome;

    private float _elapsedIncomeSeconds;

    private void Update()
    {
        _elapsedIncomeSeconds += Time.deltaTime;
        if (_elapsedIncomeSeconds > _incomeSeconds)
        {
            _elapsedIncomeSeconds = 0;
            _wallet.Earn(_income);
        }
    }

    public void Accelerate()
    {
        _incomeSeconds = Mathf.Max(_incomeSeconds - _accelerateIncomeSeconds, 0f);
    }

    public void RaiseIncome()
    {
        _income += _raiseIncome;
    }
}
