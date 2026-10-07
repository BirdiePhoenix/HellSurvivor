using UnityEngine;

[CreateAssetMenu(fileName = "SO_PlayerStartingStats", menuName = "Scriptable Objects/SO_PlayerStartingStats")]
public class SO_PlayerStartingStats : ScriptableObject
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float maxXp;
    
    public float MaxHealth => maxHealth;
    public float MaxXp => maxXp;
    public float MovementSpeed => movementSpeed;
}
