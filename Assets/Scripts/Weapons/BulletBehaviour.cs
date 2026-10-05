using System;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private BulletPool bulletPool;
    [SerializeField] private SO_Bullet bullet;
    private void Start()
    {
        bulletPool = GameObject.FindGameObjectWithTag("BulletManager").GetComponent<BulletPool>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            bulletPool.ReturnObject(gameObject);
            other.GetComponent<EnemyHealth>().TakeDamage(bullet.Damage);
        }
    }
}
