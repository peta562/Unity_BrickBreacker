using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public int level;
    public int coins;
    public int highScore;
    public int ballsAmount;
    public int score;
    public Sprite playerSprite;

    void Awake()
    {
        DontDestroyOnLoad(this);
        try
        {
            PlayerData data = SaveSystem.LoadPlayer();
            coins = data.coins;
            level = data.level;
            highScore = data.highscore;
            score = data.score;
            ballsAmount = data.ballsAmount;
            playerSprite = Resources.Load<Sprite>("Balls/" + data.spriteName);

        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public void SetData(GameManager gameManager)
    {
        coins = gameManager.coins;
        level = gameManager.level;
        highScore = gameManager.highScore;
        score = gameManager.score;
        ballsAmount = gameManager.BallsAmount;
        playerSprite = gameManager.playerSprite;
    }
}
