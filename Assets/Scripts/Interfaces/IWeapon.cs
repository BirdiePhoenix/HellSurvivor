using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public interface IWeapon
{
    public Vector2 ShootingDirection
    {
        get => throw new System.NotImplementedException();
        set => throw new System.NotImplementedException();
    }

    private IEnumerator Shoot(){
        yield break;
    }
}
