using UnityEngine;

[CreateAssetMenu(fileName = "SO_PlayerStats", menuName = "Scriptable Objects/SO_PlayerStats")]
public class SO_PlayerStats : ScriptableObject
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float maxXp;
    
    public float MaxHealth => maxHealth;
    public float MaxXp => maxXp;
    public float MovementSpeed => movementSpeed;
}
