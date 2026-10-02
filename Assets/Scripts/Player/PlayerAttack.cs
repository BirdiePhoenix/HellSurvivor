using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerSetup playerSetup;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] protected SO_Bullet bulletType;

    private Weapon subWeapon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject weapon in playerInventory.weapons)
        {
            subWeapon = weapon.GetComponent<Weapon>();
            TriggerShooting();
        }
    }
    
    public void TriggerShooting()
    {
        StartCoroutine(Shoot(bulletType));
    }

    private IEnumerator Shoot(SO_Bullet bullet)
    {
        for (int i = 0; i < bulletType.MagSize; i++)
        {
            Instantiate(bulletType.BulletPrefab);
            yield return new WaitForSeconds(bulletType.ShootingSpeed);
        }
    }
}
