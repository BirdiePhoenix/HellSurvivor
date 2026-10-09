using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas upgradeCanvas;
    
    public void UpdateUI(Slider slider, int maxSliderValue, int currentSliderValue)
    {
        slider.maxValue = maxSliderValue;
        slider.value = currentSliderValue;
    }
    
    public void EnableUpgradeMenu()
    {
        upgradeCanvas.enabled = true;
        Debug.Log("LevelUp");
    }

    public void DisableUpgradeMenu()
    {
        upgradeCanvas.enabled = false;
    }
}
