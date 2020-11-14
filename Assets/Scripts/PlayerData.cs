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
    public int score;
    public string spriteName;

    public PlayerData(GameData gameData)
    {
        level = gameData.level;
        coins = gameData.coins;
        highscore = gameData.highScore;
        score = gameData.score;
        ballsAmount = gameData.ballsAmount;
        spriteName = gameData.playerSprite.name;
    }
}
