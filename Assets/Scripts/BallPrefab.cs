using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPrefab : MonoBehaviour
{
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
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
            player.coins++;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Extra ball"))
        {
            player.BallsAmount++;
            other.gameObject.SetActive(false);
        }
    }
}
