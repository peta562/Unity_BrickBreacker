using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackBallController : MonoBehaviour
{
    public Button backButton;
    private PlayerController player;
    public Transform ground;
    public AudioClip click;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        for (int i = 0; i < player.balls.Count; i++)
        {
            if (ground.position.y + 0.3f >= player.balls[i].transform.position.y)
            {
                player.balls[i].GetComponent<Collider2D>().enabled = true;
                player.balls[i].transform.position = new Vector3(player.ballLandingPos.x, ground.position.y , ground.position.z);
            }
        }
    }

    public void OnClick()
    {
        SoundManager.instance.PlaySound(click, 1);
        StopCoroutine(player.releaseBalls);
        for (int i = 0; i < player.balls.Count; i++)
        {
            player.balls[i].GetComponent<Collider2D>().enabled = false;
            player.balls[i].velocity = ground.position * player.speed;
        }
        player.endShot = true;
    }

}
