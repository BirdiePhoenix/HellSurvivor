using System;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private float xpValue;
    private BarUI xpBar;
    private PlayerSetup playerSetup;

    private void Start()
    {
        xpBar = GameObject.FindGameObjectWithTag("XPBar").GetComponent<BarUI>();
        playerSetup = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSetup>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeXpBar();
        }
    }

    private void ChangeXpBar()
    {
        xpValue = Mathf.Clamp(playerSetup.CurrentHealth, 0, playerSetup.CurrentMaxHealth);
        xpBar.SetValue(xpValue);
    }
}
