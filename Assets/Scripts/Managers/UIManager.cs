using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject upgradeMenu;


    public void UpdateUI(Slider slider, int maxSliderValue, int currentSliderValue)
    {
        slider.maxValue = maxSliderValue;
        slider.value = currentSliderValue;
    }
    
    
}
