using UnityEngine;

public class EnemyStartingStats : MonoBehaviour
{
    //Sets the stats att the beginning of the game, when difficulty rises here is where the changes happen
    
    [SerializeField] private SO_EnemyStats enemyStats;

    private float currentMaxHealth;
    private float currentMovementSpeed;
    private float currentStrength;
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
    
    public float CurrentMaxHealth
    {
        get {return currentMaxHealth;}
        set {currentMaxHealth = value;}
    }
    public float CurrentMovementSpeed
    {
        get {return currentMovementSpeed;}
        set {currentMovementSpeed = value;}
    }
    public float CurrentStrength
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
