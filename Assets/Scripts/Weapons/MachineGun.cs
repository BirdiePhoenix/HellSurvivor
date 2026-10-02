using UnityEngine;

public class MachineGun : Weapon
{
    [SerializeField] private GameObject player;
    protected override void WeaponBehaviour()
    {
        base.WeaponBehaviour();
    }
}
