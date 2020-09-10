using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EngGameManager : MonoBehaviour
{
    private PlayerController player;
    public GameObject endGamePanel;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        endGamePanel.SetActive(false);
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Square Brick") || other.gameObject.CompareTag("Triangle Brick"))
        {
            player.endGame = true;
            endGamePanel.SetActive(true);
        }
    }

    public void Retry()
    {

        SceneManager.LoadScene("Game");
    }
    public void Quit()
    {

        SceneManager.LoadScene("Menu");
    }

}
