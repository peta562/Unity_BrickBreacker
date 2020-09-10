using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerScript : MonoBehaviour
{
    public bool release, hold;
    public Vector2 swipeDelta;
    private Vector2 initialPos;
    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if(player.ballMoving == false)
        {
            release = false;

            if(Input.GetMouseButtonDown(0))
            {
                initialPos = Input.mousePosition;
                hold = true;

            }
            else if(Input.GetMouseButtonUp(0))
            {
                release = true;
                hold = false;
                swipeDelta = (Vector2)Input.mousePosition - initialPos;
            }
            if(hold)
            {
                swipeDelta = (Vector2)Input.mousePosition - initialPos;

            }
            if(!hold)
            {
                if(swipeDelta.x < 0 || swipeDelta.y < 0)
                {
                    release = true;
                }
            }
        }
    }
}
