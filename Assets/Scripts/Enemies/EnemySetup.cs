using UnityEngine;

public class EnemySetup : MonoBehaviour
{   //This controls the stats of each different enemy
    [SerializeField] private EnemyStartingStats  startingStats;
    
    private int currentHealth;
    private int currentMaxHealth;
    private float currentMovementSpeed;
    private int currentStrength;
    private float currentAttackSpeed;
    private float currentAttackRange;
    
    private bool isInRange;
    private bool isDead;
    
    private void Start()
    {
        startingStats = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyStartingStats>();
        CurrentHealth = startingStats.CurrentMaxHealth;
        CurrentMaxHealth = startingStats.CurrentMaxHealth;
        CurrentMovementSpeed = startingStats.CurrentMovementSpeed;
        CurrentStrength = startingStats.CurrentStrength;
        CurrentAttackSpeed = startingStats.CurrentAttackSpeed;
        CurrentAttackRange = startingStats.CurrentAttackRange;
        isDead = false;
        IsInRange = false;
    }
    
    public int CurrentHealth
    {
        get => currentHealth;
        set => currentHealth = value;
    }

    public int CurrentMaxHealth
    {
        get => currentMaxHealth;
        set => currentMaxHealth = value;
    }
    
    public float CurrentMovementSpeed
    {
        get => currentMovementSpeed;
        set => currentMovementSpeed = value;
    }
    public int CurrentStrength
    {
        get => currentStrength;
        set => currentStrength = value;
    }
    public float CurrentAttackSpeed
    {
        get => currentAttackSpeed;
        set => currentAttackSpeed = value;
    }

    public float CurrentAttackRange
    {
        get => currentAttackRange;
        set => currentAttackRange = value;
    }

    public bool IsDead
    {
        get => isDead;
        set => isDead = value;
    }
    
    public bool IsInRange{
        get => isInRange;
        set => isInRange = value;
    }
}
