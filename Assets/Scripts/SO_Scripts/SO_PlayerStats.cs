using UnityEngine;

[CreateAssetMenu(fileName = "SO_PlayerStats", menuName = "Scriptable Objects/SO_PlayerStats")]
public class SO_PlayerStats : ScriptableObject
{
    [SerializeField] private int maxHealth;
    [SerializeField] private float movementSpeed;
    
    public int MaxHealth
    {
        get { return maxHealth; }
    }
    public float MovementSpeed
    {
        get { return movementSpeed; }
    }
}
