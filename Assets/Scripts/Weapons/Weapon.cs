using UnityEngine;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected SO_Bullet bulletType;

    protected virtual void WeaponBehaviour() { }
}
