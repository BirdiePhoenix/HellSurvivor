using UnityEngine;

[CreateAssetMenu(fileName = "SO_EnemyStats", menuName = "Scriptable Objects/SO_EnemyStats")]
public class SO_EnemyStats : ScriptableObject
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float strength;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackRange;
    
    public float MaxHealth
    {
        get { return maxHealth; }
    }
    public float MovementSpeed
    {
        get { return movementSpeed; }
    }
    public float Strength
    {
        get { return strength; }
    }
    public float AttackSpeed
    {
        get { return attackSpeed; }
    }

    public float AttackRange
    {
        get { return attackRange; }
    }
}
