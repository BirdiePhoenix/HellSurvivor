using UnityEngine;

public class FlyingEye : MonoBehaviour
{
    [SerializeField] private SO_EnemyStats enemyStats;

    private float currentHealth;
    private float currentMovementSpeed;
    private float currentStrength;
    private float currentAttackSpeed;
    private float currentAttackRange;
    
    
    private void Awake()
    {
        currentHealth = enemyStats.MaxHealth;
        currentMovementSpeed = enemyStats.MovementSpeed;
        currentStrength = enemyStats.Strength;
        currentAttackSpeed = enemyStats.AttackSpeed;
        currentAttackRange = enemyStats.AttackRange;
    }
    
    public float CurrentHealth
    {
        get {return currentHealth;}
        set {currentHealth = value;}
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
