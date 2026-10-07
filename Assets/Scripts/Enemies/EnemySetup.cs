using UnityEngine;

public class EnemySetup : MonoBehaviour
{   //This controls the stats of each different enemy
    [SerializeField] private EnemyStartingStats  startingStats;
    
    private float currentHealth;
    private float currentMovementSpeed;
    private float currentStrength;
    private float currentAttackSpeed;
    private float currentAttackRange;
    
    private bool isInRange;
    private bool isDead;
    
    private void Start()
    {
        startingStats = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyStartingStats>();
        currentHealth = startingStats.CurrentMaxHealth;
        currentMovementSpeed = startingStats.CurrentMovementSpeed;
        currentStrength = startingStats.CurrentStrength;
        currentAttackSpeed = startingStats.CurrentAttackSpeed;
        currentAttackRange = startingStats.CurrentAttackRange;
        isDead = false;
        IsInRange = false;
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

    public bool IsDead
    {
        get {return isDead;}
        set {isDead = value;}
    }
    
    public bool IsInRange{
        get {return isInRange;}
        set {isInRange = value;}
    }
}
