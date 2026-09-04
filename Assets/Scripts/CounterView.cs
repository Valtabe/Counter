using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.AmountChanged += DisplayAmount;
    }

    private void OnDisable()
    {
        _counter.AmountChanged -= DisplayAmount;
    }

    private void DisplayAmount()
    {
        Debug.Log(_counter.Count);
    }
}
