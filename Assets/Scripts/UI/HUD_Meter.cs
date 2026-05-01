using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Meter : MonoBehaviour
{
    [SerializeField] private Slider meter;
    [SerializeField] private TextMeshProUGUI number;

    public void Set(int maxValue, int value)
    {
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
