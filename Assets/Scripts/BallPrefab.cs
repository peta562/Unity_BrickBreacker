using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPrefab : MonoBehaviour
{
    private PlayerController player;
    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer.sprite = gameManager.playerSprite;
        Physics2D.IgnoreLayerCollision(8, 8);
    }
    
    void OnDestroy()
    {
        player.ballLandingPos = transform.position;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            gameManager.coins++;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Extra ball"))
        {
            gameManager.BallsAmount++;
            other.gameObject.SetActive(false);
        }
    }
}
