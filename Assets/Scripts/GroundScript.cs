using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private PlayerController player;
    private int numberOfEndShot;
    void Start()
    {  
        player = FindObjectOfType<PlayerController>();
        numberOfEndShot = player.BallsAmount;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("BallPrefab"))
        {
            player.balls.Remove(col.gameObject.GetComponent<Rigidbody2D>());
            Destroy(col.gameObject);
            numberOfEndShot--;
            if(numberOfEndShot == 0)
            {
                player.endShot = true;
                numberOfEndShot = player.BallsAmount;
            }
        }
        if(col.gameObject.CompareTag("Coin") || col.gameObject.CompareTag("Extra ball"))
        {
            col.gameObject.SetActive(false);
        }
    }
}
