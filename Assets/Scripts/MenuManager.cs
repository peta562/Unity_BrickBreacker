using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioClip click;
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
