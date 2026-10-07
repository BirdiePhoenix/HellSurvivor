using System;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private int xpValue;
    private XPManager playerXp;

    private void Start()
    {
        playerXp = GameObject.FindGameObjectWithTag("Canvas").GetComponent<XPManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerXp.GainXp(xpValue);
        }
    }
}
