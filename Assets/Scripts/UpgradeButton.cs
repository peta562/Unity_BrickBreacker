using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Image icon;
    public Text priceText;
    public int price;
    private MenuManager menuManager;
    

    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();
        priceText.text = price.ToString();
    }

    
    public void OnClick()
    {
        if(menuManager.gameData.coins >= price)
        {
            menuManager.gameData.coins -= price;
            menuManager.coinsText.text = menuManager.gameData.coins.ToString();
            menuManager.gameData.playerSprite = icon.sprite;
        }
    }
}
