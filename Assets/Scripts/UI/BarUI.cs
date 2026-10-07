using UnityEngine;
using UnityEngine.Rendering;

public class BarUI : MonoBehaviour
{
    public float Value, MaxValue, BarWidth, BarHeight;
    [SerializeField] private RectTransform bar;

    public void SetMaxValue(float maxValue)
    {
        MaxValue = maxValue;
    }

    public void SetValue(float value)
    {
        Value = value;
        float newWidth = (Value / MaxValue) * BarWidth;

        bar.sizeDelta = new Vector2(newWidth, BarHeight);
    }
}
