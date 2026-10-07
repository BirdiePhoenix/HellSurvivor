using UnityEngine;

[CreateAssetMenu(fileName = "SO_PlayerStats", menuName = "Scriptable Objects/SO_PlayerStats")]
public class SO_PlayerStats : ScriptableObject
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float movementSpeed;
    
    public float MaxHealth
    {
        get { return maxHealth; }
    }
    public float MovementSpeed
    {
        get { return movementSpeed; }
    }
}
