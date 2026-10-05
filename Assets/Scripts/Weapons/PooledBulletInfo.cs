using System.Collections.Generic;
using UnityEngine;

public class PooledBulletInfo : MonoBehaviour
{
    public string BulletName;
    public List<GameObject> InactiveBullets = new List<GameObject>();
}
