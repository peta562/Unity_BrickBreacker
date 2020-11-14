using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public AudioClip click;
    public Text coinsText;
    public GameObject shopPanel;
    public GameData gameData;

    void Awake()
    {
        gameData = FindObjectOfType<GameData>();
        coinsText.text = gameData.coins.ToString();
    }
    public void StartGame()
    {
        SaveSystem.SavePlayer(gameData);
        SceneManager.LoadScene("Game");
        SoundManager.instance.PlaySound(click, 0.7f);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void OpenShop()
    {
        shopPanel.SetActive(true);
    }
    public void CloseShop()
    {
        shopPanel.SetActive(false);
    }
}
