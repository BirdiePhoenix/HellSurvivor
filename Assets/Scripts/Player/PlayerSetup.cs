using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] private SO_PlayerStats playerStats;
    //private static PlayerSetup playerSetup;
    private int currentHealth;
    private float currentMovementSpeed;
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
        currentHealth = playerStats.MaxHealth;
        currentMovementSpeed = playerStats.MovementSpeed;
        isDead = false;
    }
    
    public int CurrentHealth
    {
        get {return currentHealth;}
        set {currentHealth = value;}
    }
    
    public float CurrentMovementSpeed
    {
        get {return currentMovementSpeed;}
        set {currentMovementSpeed = value;}
    }

    public bool IsDead
    {
        get {return isDead;}
        set {isDead = value;}
    }
}
