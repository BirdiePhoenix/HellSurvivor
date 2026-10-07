using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] private SO_PlayerStartingStats playerStats;
    //private static PlayerSetup playerSetup;
    private float currentHealth;
    private float currentMaxHealth;
    private float currentMovementSpeed;
    private float currentXp;
    private float currentMaxXp;
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

    public float CurrentXp
    {
        get => currentXp;
        set => currentXp = value;
    }

    public float CurrentMaxXp
    {
        get => currentMaxXp;
        set => currentMaxXp = value;
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
