using System;
using UnityEngine;

public class SGRotate : MonoBehaviour
{
    [SerializeField] private GameObject shotGun;

    // private void Update()
    // {
    //     if (shotGun.activeInHierarchy)
    //     {
    //         
    //     }
    // }

    public void RotateGun(Vector2 direction)
    {
        shotGun.transform.rotation = Quaternion.Euler(direction.x,direction.y, 0f);
    }
}
