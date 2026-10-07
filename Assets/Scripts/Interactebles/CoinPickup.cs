using System;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private float xpValue;
    private PlayerXp playerXp;

    private void Start()
    {
        playerXp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerXp>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerXp.GainXp(xpValue);
        }
    }
}
