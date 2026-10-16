using System;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    //Redo with SO
    [SerializeField] private SO_Coin coinSO;
    private XPManager playerXp;
    private CoinPool coinPool;

    private void Start()
    {
        coinPool = GameObject.FindGameObjectWithTag("PickUpManager").GetComponent<CoinPool>();
        playerXp = GameObject.FindGameObjectWithTag("GameManager").GetComponent<XPManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerXp.GainXp(coinSO.xpValue);
            coinPool.ReturnObject(gameObject);
        }
    }
}
