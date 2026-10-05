using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.Linq;

public class BulletPoolManager : MonoBehaviour
{
    public static List<PooledBulletInfo> ObjectPools = new List<PooledBulletInfo>();

    public static GameObject SpawnBullet(GameObject bulletToSpawn, Vector3 spawnPos, Quaternion spawnRotation)
    {
        PooledBulletInfo pool = ObjectPools.Find(p => p.BulletName == bulletToSpawn.name);

        // PooledBulletInfo pool = null;
        // foreach (PooledBulletInfo p in ObjectPools)
        // {
        //     if (p.BulletName == bulletToSpawn.name)
        //     {
        //         pool = p;
        //         break;
        //     }
        // }

        //If pool doesn't exist, create it
        if (pool == null)
        {
            pool = new PooledBulletInfo() { BulletName = bulletToSpawn.name };
            ObjectPools.Add(pool);
        }
        
        //Check if there's any inactive objects

        GameObject spawnableBullet = pool.InactiveBullets.FirstOrDefault();
        // GameObject spawnableObject = null;
        // foreach (GameObject obj in pool.InactiveBullets)
        // {
        //     if (obj != null)
        //     {
        //         spawnableObject = obj;
        //         break;
        //     }
        // }

        if (spawnableBullet == null)
        {
            // No inactive bullet, create one
            spawnableBullet = Instantiate(bulletToSpawn, spawnPos, spawnRotation);
        }
        else
        {
            //If inactive bullet, ractivate
            spawnableBullet.transform.position = spawnPos;
            spawnableBullet.transform.rotation = spawnRotation;
            pool.InactiveBullets.Remove(spawnableBullet);
            spawnableBullet.SetActive(true);
        }

        return spawnableBullet;
    }

    public static void ReturnBulletPool(GameObject obj)
    {
        string returnBulletName = obj.name.Substring(0, obj.name.Length - 7); //-7 removes (Clone) from the gameobject

        PooledBulletInfo pool = ObjectPools.Find(p => p.BulletName == returnBulletName);

        if (pool == null)
        {
            Debug.LogWarning($"There isn't an object with the name {obj.name} in the pool.");
        }
        else
        {
            obj.SetActive(false);
            pool.InactiveBullets.Add(obj);
        }
    }
}
