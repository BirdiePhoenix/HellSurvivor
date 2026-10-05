using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class FireProjectile : MonoBehaviour
{
    //Redo!!!
    [SerializeField] private DirectionState directionState;
    [SerializeField] private SO_Bullet mgBullet;
    [SerializeField] private BulletPool bulletPool;

    private DirectionState.LookDirection lookDirection;
    
    private void Start()
    {
        bulletPool = GameObject.FindGameObjectWithTag("BulletManager").GetComponent<BulletPool>();
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
            switch (directionState.CurrentDirection)
            {
                case DirectionState.LookDirection.Right:
                    rb.linearVelocity = bullet.transform.right * mgBullet.ShootingSpeed;
                    break;
                case DirectionState.LookDirection.Left:
                    rb.linearVelocity = bullet.transform.right * -mgBullet.ShootingSpeed;
                    break;
                case DirectionState.LookDirection.Up:
                    rb.linearVelocity = bullet.transform.up * mgBullet.ShootingSpeed;
                    break;
                case DirectionState.LookDirection.Down:
                    rb.linearVelocity = bullet.transform.up * -mgBullet.ShootingSpeed;
                    break;
                default:
                    break;
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
