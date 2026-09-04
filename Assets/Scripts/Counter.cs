using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private InputReader _inputReader;

    public int Count { get; private set; }

    public event Action AmountChanged;

    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private void Start()
    {
        Count = 0;
        _wait = new WaitForSeconds(_delay);
    }

    private void OnEnable()
    {
        _inputReader.MouseClicked += SwitchCountdown;
    }

    private void OnDisable()
    {
        _inputReader.MouseClicked -= SwitchCountdown;
    }

    private void SwitchCountdown()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        else
        {
            _coroutine = StartCoroutine(IncreaseCounter());
        }
    }

    private IEnumerator IncreaseCounter()
    {
        while (true)
        {
            yield return _wait;
            Count++;
            AmountChanged?.Invoke();
        }
    }
}