using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public interface IWeapon
{
    public void WeaponBehaviour() { }
    
    private IEnumerator Shoot(){
        yield break;
    }
}
