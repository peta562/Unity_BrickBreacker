using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpriteGlow;

[RequireComponent(typeof(SpriteGlowEffect))]
public class BrickHealthManager : MonoBehaviour
{
    public GameObject brickDeathParticle;
    public int brickHealth;
    private Text brickHealthText;
    private GameManager gameManager;
    private SpriteGlowEffect glow;
    private PlayerController player;
    public AudioClip ballHit;
    
    void Start()
    {
        brickHealthText = GetComponentInChildren<Text>();
        gameManager = FindObjectOfType<GameManager>();
        glow = GetComponent<SpriteGlowEffect>();
        player = FindObjectOfType<PlayerController>();
        glow.enabled = false;
        brickHealthText.transform.rotation = Quaternion.Euler(0,0,0);
        brickHealth = gameManager.level;
    }

    void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
        brickHealthText = GetComponentInChildren<Text>();
        brickHealthText.transform.rotation = Quaternion.Euler(0,0,0);
        brickHealth = gameManager.level;
    }
    void Update()
    {
        brickHealthText.text = "" + brickHealth;
        if(brickHealth <= 0)
        {
            gameManager.score += gameManager.level;
            player.scoreNumber.text = gameManager.score.ToString();
            if (gameManager.score > gameManager.highScore)
            {
                gameManager.highScore = gameManager.score;
            }
            this.gameObject.SetActive(false);
            Instantiate(brickDeathParticle, transform.position, Quaternion.identity);
            glow.enabled = false;
        }
    }

    void TakeDamage(int damageToTake)
    {
        brickHealth -= damageToTake;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("BallPrefab"))
        {
            StartCoroutine(StartGlow());
            SoundManager.instance.PlaySound(ballHit, 0.6f);
            TakeDamage(1);
        }
    }

    private IEnumerator StartGlow()
    {
        glow.enabled = true;
        yield return new WaitForSeconds(0.1f);
        glow.enabled = false;
    }
  
}
