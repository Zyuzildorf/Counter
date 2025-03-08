using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _smoothIncreaseDuration = 0.5f;

    private bool _isCounting = false;

    public event Action<int> CounterValueChanged; 
    public int _counterValue { get; private set; }

    private void Start()
    {
        _counterValue = 0;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ToggleCounter();
        }
    }

    public void ToggleCounter()
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
        WaitForSeconds waitForSeconds = new WaitForSeconds(_smoothIncreaseDuration);

        while (_isCounting)
        {
            yield return waitForSeconds;
            _counterValue++;
            CounterValueChanged?.Invoke(_counterValue);
        }
    }
}