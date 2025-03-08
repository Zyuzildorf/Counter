using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CounterValueChanged += OnCounterValueChanged;
    }

    private void OnDisable()
    {
        _counter.CounterValueChanged -= OnCounterValueChanged;
    }

    private void OnCounterValueChanged(int counterValue)
    {
        _counterText.text = counterValue.ToString();
    }
}