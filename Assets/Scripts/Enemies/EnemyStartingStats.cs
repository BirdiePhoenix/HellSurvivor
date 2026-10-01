using UnityEngine;

public class EnemyStartingStats : MonoBehaviour
{
    //Create list and loop
    
    [SerializeField] private SO_EnemyStats enemyStats;

    private int currentMaxHealth;
    private float currentMovementSpeed;
    private int currentStrength;
    private float currentAttackSpeed;
    private float currentAttackRange;
    
    
    private void Awake()
    {
        currentMaxHealth = enemyStats.MaxHealth;
        currentMovementSpeed = enemyStats.MovementSpeed;
        currentStrength = enemyStats.Strength;
        currentAttackSpeed = enemyStats.AttackSpeed;
        currentAttackRange = enemyStats.AttackRange;
    }
    
    public int CurrentMaxHealth
    {
        get {return currentMaxHealth;}
        set {currentMaxHealth = value;}
    }
    public float CurrentMovementSpeed
    {
        get {return currentMovementSpeed;}
        set {currentMovementSpeed = value;}
    }
    public int CurrentStrength
    {
        get {return currentStrength;}
        set {currentStrength = value;}
    }
    public float CurrentAttackSpeed
    {
        get {return currentAttackSpeed;}
        set {currentAttackSpeed = value;}
    }

    public float CurrentAttackRange
    {
        get { return currentAttackRange; }
        set { currentAttackRange = value; }
    }
}
