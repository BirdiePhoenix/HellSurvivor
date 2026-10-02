using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected SO_Bullet bulletType;

    protected virtual void WeaponBehaviour() { }
    
    public virtual void TriggerShooting(){}
    
    protected virtual IEnumerator Shoot(){
        yield break;
    }
}
