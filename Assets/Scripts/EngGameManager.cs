using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EngGameManager : MonoBehaviour
{
    private PlayerController player;
    private GameManager gameManager;
    public GameObject endGamePanel;
    public AudioClip click;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerController>();
        endGamePanel.SetActive(false);
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Square Brick") || other.gameObject.CompareTag("Triangle Brick"))
        {
            player.endGame = true;
            endGamePanel.SetActive(true);
            gameManager.level = 1;
            gameManager.BallsAmount = 1;
            SaveSystem.SavePlayer(gameManager);
        }
    }

    public void Retry()
    {
        SoundManager.instance.PlaySound(click, 0.8f);
        SceneManager.LoadScene("Game");
    }
    public void Quit()
    {
        SoundManager.instance.PlaySound(click, 0.8f);
        SceneManager.LoadScene("Menu");
    }

}
