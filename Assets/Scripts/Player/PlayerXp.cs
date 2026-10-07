using System;
using UnityEngine;

public class PlayerXp : MonoBehaviour
{
    [SerializeField] private PlayerSetup playerSetup;
    private BarUI xpBar;
    private float barValue;

    private void Start()
    {
        xpBar = GameObject.FindGameObjectWithTag("XPBar").GetComponent<BarUI>();
    }

    public void GainXp(float amount)
    {
        //playerSetup.CurrentXp += amount;
        ChangeXpBar();
    }

    private void ChangeXpBar()
    {
        barValue = Mathf.Clamp(playerSetup.CurrentXp, 0, playerSetup.CurrentMaxXp);
        xpBar.SetValue(barValue);
    }
}
