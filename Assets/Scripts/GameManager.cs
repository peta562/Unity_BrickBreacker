using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject squareBrick;
    public GameObject triangleBrick;
    public GameObject extraBall;
    public GameObject coin;
    public int coins = 0;
    public int score = 0;
    public int highScore = 0;
    public int BallsAmount = 1;
    public int level;
    public Sprite playerSprite;
    public List<GameObject> objectsInScene;

    private ObjectPool objectPool;
    private int maxExtraBallNum = 1;
    public GameData gameData;

    void Awake()
    {
        gameData = FindObjectOfType<GameData>();
        level = gameData.level;
        BallsAmount = gameData.ballsAmount;
        score = gameData.score;
        coins = gameData.coins;
        highScore = gameData.highScore;
        
        playerSprite = Resources.Load<Sprite>("Balls/" + gameData.playerSprite.name);
    }
    void Start()
    {
        
        objectPool = FindObjectOfType<ObjectPool>();
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            int brickToCreate = UnityEngine.Random.Range(0, 4);
            if(brickToCreate == 0)
            {
                objectsInScene.Add(Instantiate(squareBrick, spawnPoints[i].position, Quaternion.identity));
            }
            else if (brickToCreate == 1)
            {
                int triangleBrickToCreate = UnityEngine.Random.Range(0, 5);
                switch(triangleBrickToCreate)
                {
                    case 1:
                        objectsInScene.Add(Instantiate(triangleBrick,spawnPoints[i].position, Quaternion.Euler(0,0,0)));
                        break;
                    case 2:
                        objectsInScene.Add(Instantiate(triangleBrick,spawnPoints[i].position, Quaternion.Euler(0,0,90)));
                        break;
                    case 3:
                        objectsInScene.Add(Instantiate(triangleBrick,spawnPoints[i].position, Quaternion.Euler(0,0,180)));
                        break;
                    case 4:
                        objectsInScene.Add(Instantiate(triangleBrick,spawnPoints[i].position, Quaternion.Euler(0,0,270)));
                        break; 
                }
            }
            else if (brickToCreate == 2)
            {
                objectsInScene.Add(Instantiate(coin, spawnPoints[i].position, Quaternion.identity));
            }
            else 
            {
                if(maxExtraBallNum == 1)
                {
                    objectsInScene.Add(Instantiate(extraBall, spawnPoints[i].position, Quaternion.identity));
                    maxExtraBallNum = 0;
                }
            }
        }
    }


    public void PlaceBricks()
    {
        level++;
        maxExtraBallNum = 1;
        foreach(Transform position in spawnPoints)
        {
            int brickToCreate = UnityEngine.Random.Range(0, 4);
            if(brickToCreate == 0)
            {
                GameObject brick = objectPool.GetPooledObject("Square Brick");
                objectsInScene.Add(brick);
                if(brick != null)
                {
                    brick.transform.position = position.position;
                    brick.transform.rotation = Quaternion.identity;
                    brick.SetActive(true);
                }
            }
            else if (brickToCreate == 1)
            {
                GameObject brick = objectPool.GetPooledObject("Triangle Brick");
                objectsInScene.Add(brick);
                int triangleBrickToCreate = UnityEngine.Random.Range(0, 5);
                switch(triangleBrickToCreate)
                {
                    case 1:
                        brick.transform.rotation = Quaternion.Euler(0,0,0);
                        break;
                    case 2:
                        brick.transform.rotation = Quaternion.Euler(0,0,90);
                        break;
                    case 3:
                        brick.transform.rotation = Quaternion.Euler(0,0,180);
                        break;
                    case 4:
                        brick.transform.rotation = Quaternion.Euler(0,0,270);
                        break;
                    
                }
                if(brick != null)
                {
                    brick.transform.position = position.position;
                    brick.SetActive(true);
                }
            }
            else if(brickToCreate == 2)
            {
                GameObject coin = objectPool.GetPooledObject("Coin");
                objectsInScene.Add(coin);
                if(coin != null)
                {
                    coin.transform.position = position.position;
                    coin.transform.rotation = Quaternion.identity;
                    coin.SetActive(true);
                }
            }
            else
            {
                if(maxExtraBallNum == 1)
                {
                    GameObject ball = objectPool.GetPooledObject("Extra ball");
                    objectsInScene.Add(ball);
                    if(ball != null)
                    {
                        ball.transform.position = position.position;
                        ball.transform.rotation = Quaternion.identity;
                        ball.SetActive(true);
                    }
                maxExtraBallNum = 0;
                }
            }
        }
        
    }

    void OnApplicationQuit()
    {
        gameData.SetData(this);
        SaveSystem.SavePlayer(gameData);
    }
    
}
