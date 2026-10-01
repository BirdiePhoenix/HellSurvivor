using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField] private EnemyAttack enemyAttack;
    [SerializeField] private EnemySetup enemySetup;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemySetup.IsInRange = true;
            enemyAttack.TriggerAttack();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemySetup.IsInRange = false;
        }
    }
}
