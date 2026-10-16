using UnityEngine;

public class PlayerSetup : MonoBehaviour, ISetup
{
    [SerializeField] private SO_PlayerStartingStats playerStats;
    private int currentHealth;
    private int currentMaxHealth;
    private float currentMovementSpeed;
    private int currentXp;
    private int currentMaxXp;
    private int currentLvl;
    
    private bool isDead;
    

    private void Awake()
    {
        GetData();
    }
    
    private void Start()
    {
        IsDead = false;
    }

    public void GetData()
    {
        CurrentHealth = playerStats.MaxHealth;
        CurrentMaxHealth = playerStats.MaxHealth;
        CurrentXp = 0;
        CurrentMaxXp = playerStats.MaxXp;
        
        CurrentMovementSpeed = playerStats.MovementSpeed;
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

    public int CurrentXp
    {
        get => currentXp;
        set => currentXp = value;
    }

    public int CurrentMaxXp
    {
        get => currentMaxXp;
        set => currentMaxXp = value;
    }

    public int CurrentLvl
    {
        get => currentLvl;
        set => currentLvl = value;
    }

    public float CurrentMovementSpeed
    {
        get => currentMovementSpeed;
        set => currentMovementSpeed = value;
    }

    public bool IsDead
    {
        get => isDead;
        set => isDead = value;
    }
}
