using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] private SO_PlayerStartingStats playerStats;
    //private static PlayerSetup playerSetup;
    private float currentHealth;
    private float currentMaxHealth;
    private float currentMovementSpeed;
    private int currentXp;
    private int currentMaxXp;
    private int currentLvl;
    
    private bool isDead;
    

    private void Awake()
    {
        // if (playerSetup != null && playerSetup != this)
        // {
        //     Destroy(gameObject);
        // }
        // else
        // {
        //     playerSetup = this;
        // }
    }
    
    private void Start()
    {
        //DontDestroyOnLoad(gameObject);
        CurrentHealth = playerStats.MaxHealth;
        CurrentMaxHealth = playerStats.MaxHealth;
        CurrentXp = 0;
        CurrentMaxXp = playerStats.MaxXp;
        
        CurrentMovementSpeed = playerStats.MovementSpeed;
        IsDead = false;
    }
    
    public float CurrentHealth
    {
        get => currentHealth;
        set => currentHealth = value;
    }

    public float CurrentMaxHealth
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
