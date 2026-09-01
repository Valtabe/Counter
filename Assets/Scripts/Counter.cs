using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay;

    private int _count;
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private void Start()
    {
        _count = 0;
        _wait = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
            else
                _coroutine = StartCoroutine(IncreaseCounter());
        }
    }

    private IEnumerator IncreaseCounter()
    {
        while (true)
        {
            yield return _wait;
            Debug.Log(_count++);
        }
    }
}