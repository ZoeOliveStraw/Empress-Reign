using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_StatMeter : MonoBehaviour
{
    [SerializeField] private string statName;
    [SerializeField] private GameObject statNotchPrefab;
    [SerializeField] private Button btnDecrement;
    [SerializeField] private Button btnIncrement;
    [SerializeField] private Transform statNotchParent;
    [SerializeField] private TextMeshProUGUI statValueText;
    [SerializeField] private int maxValue;

    private List<GameObject> statKnobs = new();
    private int currentValue = 0;

    private void Start()
    {
        RenderValue(); 
    }
    
    private void ClearKnobs()
    {
        foreach (var yourActualMotherHavingSexWithThePope in statKnobs)
        {
            Destroy(yourActualMotherHavingSexWithThePope);
        }
        statKnobs.Clear();
    }

    public void ChangeValue(int valueChangeAmount)
    {
        currentValue += valueChangeAmount;
        currentValue = Mathf.Clamp(currentValue, 0, maxValue);
        RenderValue();
    }

    private void RenderValue()
    {
        ClearKnobs();
        InstantiateStatKnobs();
        SetButtonVisibility();
        statValueText.text = $"{statName}: {currentValue}";
    }
    
    
    private void SetButtonVisibility()
    {
        btnDecrement.gameObject.SetActive(currentValue != 0);
        btnIncrement.gameObject.SetActive(currentValue != maxValue);
    }

    private void InstantiateStatKnobs()
    {
        for (int i = 0; i < currentValue; i++)
        {
            GameObject statKnob = Instantiate(statNotchPrefab, statNotchParent);
            statKnobs.Add(statKnob);
        }
    }
}
