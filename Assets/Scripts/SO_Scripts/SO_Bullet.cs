using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "SO_Bullet", menuName = "Scriptable Objects/SO_Bullet")]
public class SO_Bullet : ScriptableObject
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootingSpeed;
    [SerializeField] private float shootingRange;
    [SerializeField] private float reloadSpeed;
    [SerializeField] private int magSize;

    public GameObject BulletPrefab
    {
        get { return bulletPrefab; }
    }
    
    public float ShootingSpeed
    {
        get { return shootingSpeed; }
    }

    public float ShootingRange
    {
        get { return shootingRange; }
    }
    
    public float ReloadSpeed
    {
        get { return reloadSpeed; }
    }

    public int MagSize
    {
        get { return magSize; }
    }
}
