using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<GameObject> weapons;
    [SerializeField] private GameObject machineGun;

    private void Start()
    {
        AddWeapon(machineGun);
    }

    private void AddWeapon(GameObject weapon)
    {
        weapons.Add(weapon);
    }
}
