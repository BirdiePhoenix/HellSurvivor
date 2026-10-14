using System;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite[] weaponImages;
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private WeaponStorage weaponStorage;

    private void Start()
    {
        AddSprite();
    }

    public void OnButtonClick()
    {
        weaponStorage.EnableWeaponIcons();
        if (weaponStorage.WeaponIndex < weaponImages.Length)
        {
            AddSprite();
        }
        weaponStorage.EnableWeapons();
        gameStateManager.SetGameState(GameStateManager.GameState.Play);
    }

    private void AddSprite()
    {
        image.sprite = weaponImages[weaponStorage.WeaponIndex];
    }
}
