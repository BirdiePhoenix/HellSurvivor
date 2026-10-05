using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    //Redo!!!
    [SerializeField] private DirectionState directionState;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;

    private void TriggerShooting()
    {
        if (directionState.CurrentDirection == DirectionState.LookDirection.Left)
        {
            //BulletPoolManager.SpawnBullet(bulletPrefab, bulletSpawnPoint.position)
        }
        else if (directionState.CurrentDirection == DirectionState.LookDirection.Right)
        {
            
        }
    }
}
