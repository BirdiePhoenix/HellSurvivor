using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerSetup playerSetup;
    [SerializeField] private MoveStateManager moveStateManager;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private HealthManager healthManager;
    private GameStateManager gameStateManager;

    private void Start()
    {
        healthManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<HealthManager>();
        gameStateManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateManager>();
    }

    public void TakeDamage(int damage)
    {
        healthManager.UpdateHealth(-damage);
        StartCoroutine(ChangeColor());
        
        if (playerSetup.CurrentHealth <= 0 && !playerSetup.IsDead)
        {
            moveStateManager.SetMoveState(MoveStateManager.MoveState.Die);
            playerSetup.IsDead = true;
            Debug.Log("Player is dead");
        }
        Debug.Log("Hit");
    }

    public void PlayerDeath()
    {
        gameStateManager.SetGameState(GameStateManager.GameState.GameOver);
    }

    private IEnumerator ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material.color = Color.white;
    }
}
