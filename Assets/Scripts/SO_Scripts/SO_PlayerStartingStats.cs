using UnityEngine;

[CreateAssetMenu(fileName = "SO_PlayerStartingStats", menuName = "Scriptable Objects/SO_PlayerStartingStats")]
public class SO_PlayerStartingStats : ScriptableObject
{
    [SerializeField] private int maxHealth;
    [SerializeField] private float movementSpeed;
    [SerializeField] private int maxXp;
    
    public int MaxHealth => maxHealth;
    public int MaxXp => maxXp;
    public float MovementSpeed => movementSpeed;
}
