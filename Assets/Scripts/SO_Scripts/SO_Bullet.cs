using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "SO_Bullet", menuName = "Scriptable Objects/SO_Bullet")]
public class SO_Bullet : ScriptableObject
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootingSpeed;
    [SerializeField] private float shootingRange;
    
    
    public float ShootingSpeed
    {
        get { return shootingSpeed; }
    }

    public float ShootingRange
    {
        get { return shootingRange; }
    }
}
