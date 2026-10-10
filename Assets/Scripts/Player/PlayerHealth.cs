using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerSetup playerSetup;
    [FormerlySerializedAs("moveState")] [SerializeField] private MoveStateManager moveStateManager;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private HealthManager healthManager;

    private void Start()
    {
        healthManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<HealthManager>();
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

    private IEnumerator ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material.color = Color.white;
    }
}
