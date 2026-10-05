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
            //if (directionState.CurrentDirection == DirectionState.LookDirection.Left)
                rb.linearVelocity = bullet.transform.forward * mgBullet.ShootingSpeed;
        }

        StartCoroutine(DeactivateBullet(bullet));
        yield return new WaitForSeconds(mgBullet.ShootingSpeed);
        StartCoroutine(Shoot());
    }

    private IEnumerator DeactivateBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(2f);
        bulletPool.ReturnObject(bullet);
    }
}
