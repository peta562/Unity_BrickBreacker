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

    void Awake()
    {
        try
        {
            PlayerData data = SaveSystem.LoadPlayer();
            coinsText.text = data.coins.ToString();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        SoundManager.instance.PlaySound(click, 0.7f);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
