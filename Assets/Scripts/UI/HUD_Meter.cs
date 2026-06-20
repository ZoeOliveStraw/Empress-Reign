using System;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Meter : MonoBehaviour
{
    [SerializeField] private Slider meter;
    [SerializeField] private TextMeshProUGUI number;

    public void Initialize(int currentValue, int minValue, int maxValue)
    {
        meter.maxValue = maxValue;
        meter.minValue = minValue;
        meter.SetValueWithoutNotify(currentValue);
        number.text = currentValue.ToString();
    }

    public void Set(int maxValue, int value)
    {
        Debug.LogWarning($"HUD_Meter Set, min: {meter.minValue}, max: {meter.maxValue}");
        Math.Clamp(value, meter.minValue, meter.maxValue);
        meter.maxValue = maxValue;
        meter.SetValueWithoutNotify(value);
        number.text = value.ToString();
    }
    
    public void Set(int value)
    {
        meter.SetValueWithoutNotify(value);
        number.text = value.ToString();
    }
}
