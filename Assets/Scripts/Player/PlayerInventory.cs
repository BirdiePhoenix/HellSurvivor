using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<GameObject> weapons;
    [SerializeField] private WeaponStorage weaponStorage;
    [SerializeField] private GameObject machineGun;

    private void Start()
    {
        weaponStorage = GameObject.FindGameObjectWithTag("Storage").GetComponent<WeaponStorage>();
        machineGun = weaponStorage.weapons[0];
        AddWeapon(machineGun);
    }

    private void AddWeapon(GameObject weapon)
    {
        weapons.Add(weapon);
    }
}
