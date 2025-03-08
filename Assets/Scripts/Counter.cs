using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _smoothIncreaseDuration = 0.5f;

    private bool _isCounting = false;
    private WaitForSeconds _waitForSeconds;

    public event Action<int> CounterValueChanged; 
    public int CounterValue { get; private set; }

    private void Awake()
    {
        CounterValue = 0;
        _waitForSeconds = new WaitForSeconds(_smoothIncreaseDuration);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ToggleCounter();
        }
    }

    private void ToggleCounter()
    {
        if (_isCounting == false)
        {
            _isCounting = true;
            StartCoroutine(IncreaseCounterValue());
            Debug.Log("Счётчик запущен.");
        }
        else
        {
            _isCounting = false;
            StopCoroutine(IncreaseCounterValue());
            Debug.Log("Счётчик остановлен.");
        }
    }

    private IEnumerator IncreaseCounterValue()
    {
        while (_isCounting)
        {
            yield return _waitForSeconds;
            CounterValue++;
            CounterValueChanged?.Invoke(CounterValue);
        }
    }
}