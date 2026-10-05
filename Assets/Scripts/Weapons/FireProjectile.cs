using System;
using System.Collections;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    //Redo!!!
    [SerializeField] private DirectionState directionState;
    [SerializeField] private SO_Bullet mgBullet;
    [SerializeField] private BulletPool bulletPool;
    

    private void Start()
    {
        bulletPool = GameObject.FindGameObjectWithTag("PoolManager").GetComponent<BulletPool>();
        StartCoroutine(Shoot());
    }
    
    private IEnumerator Shoot()
    {
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            if (directionState.CurrentDirection == DirectionState.LookDirection.Left)
            {
                rb.linearVelocity = bullet.transform.right * -mgBullet.ShootingSpeed;
            }
            else if (directionState.CurrentDirection == DirectionState.LookDirection.Right)
            {
                rb.linearVelocity = bullet.transform.right * mgBullet.ShootingSpeed;
            }
        }

        StartCoroutine(DeactivateBullet(bullet));
        yield return new WaitForSeconds(mgBullet.ReloadSpeed);
        StartCoroutine(Shoot());
    }

    private IEnumerator DeactivateBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(mgBullet.ShootingRange);
        bulletPool.ReturnObject(bullet);
    }
}
