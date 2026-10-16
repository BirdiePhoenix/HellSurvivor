using UnityEngine;

public class EnemySetup : MonoBehaviour
{   //This controls the stats of each different enemy
    
    [Header("Stats")]
    [SerializeField] private SO_EnemyStats enemyStats;
    private int currentHealth;
    private int currentMaxHealth;
    private float currentMovementSpeed;
    private int currentStrength;
    private float currentAttackSpeed;
    private float currentAttackRange;
    
    private bool isInRange;
    private bool isDead;
    
    public enum EnemyType
    {
        FlyingEye,
        Slime
    }

    private EnemyType enemyType;
    public EnemyType CurrentEnemyType
    {
        get => enemyType;
        set => enemyType = value;
    }
    
    private void Start()
    {
        CurrentHealth = enemyStats.MaxHealth;
        CurrentMaxHealth = enemyStats.MaxHealth;
        CurrentMovementSpeed = enemyStats.MovementSpeed;
        CurrentStrength = enemyStats.Strength;
        CurrentAttackSpeed = enemyStats.AttackSpeed;
        CurrentAttackRange = enemyStats.AttackRange;
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
