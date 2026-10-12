using System;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite[] weaponImages;
    [SerializeField] private GameStateManager gameStateManager;

    private int i;

    private void Start()
    {
        i = 0;
        AddSprite();
    }

    public void OnButtonClick()
    {
        if (i < weaponImages.Length)
        {
            AddSprite();
        }
        gameStateManager.SetGameState(GameStateManager.GameState.Play);
    }

    private void AddSprite()
    {
        image.sprite = weaponImages[i];
        i++;
    }
}
