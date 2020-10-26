using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int coins;
    public int level;
    public int highscore;
    public int ballsAmount;

    public PlayerData(GameManager gameData)
    {
        level = gameData.level;
        coins = gameData.coins;
        highscore = gameData.highScore;
        ballsAmount = gameData.BallsAmount;
    }
}
