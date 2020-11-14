using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text coinsNumber;
    public Text scoreNumber;

    public bool ballMoving;
    public bool endGame;
    public float duration = 0.5f;
    public bool endShot;
    public float speed = 14f;

    public List<Rigidbody2D> balls;
    public Rigidbody2D _ballPrefab;
    public Transform wrapper;
    public Vector3 ballLandingPos;
    public GameObject backBallButton;
    

    private const float maxPull = 160f;

    private InputManagerScript InputInstance;
    private GameManager gameManager;
    private Text BallsAmountText;
    private bool ballRelease;
    private SpriteRenderer playerSprite;

    [SerializeField]
    private Vector3 ballDirection;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        BallsAmountText = GetComponentInChildren<Text>();
        BallsAmountText.text = "x" + gameManager.BallsAmount;
        ballLandingPos = new Vector3(0, transform.position.y, transform.position.z);
        wrapper.parent.gameObject.SetActive(false);
        InputInstance = FindObjectOfType<InputManagerScript>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerSprite.sprite = gameManager.playerSprite;
        endShot = false;
        coinsNumber.text = gameManager.coin.ToString();
        scoreNumber.text = gameManager.score.ToString();
    }

    
    void FixedUpdate()
    {
        if(!endGame)
        {
            if(GameObject.Find("BallPrefab(Clone)"))
            {
                ballMoving = true;
            }
            else
            {
                ballMoving = false;
            }
            if(ballMoving)
            {
                playerSprite.enabled = false;
                BallsAmountText.gameObject.SetActive(false);
            }
            if(!ballMoving)
            {
                playerSprite.enabled = true;
                backBallButton.SetActive(false);
                transform.position = new Vector3(ballLandingPos.x, transform.position.y, transform.position.z);
                ControllPlayer();
            }
            if(ballRelease)
            {
                InputInstance.swipeDelta = Vector2.zero;
                StartCoroutine(waitToReleaseBall());
                backBallButton.SetActive(true);
                ballRelease = false;
            }
            if(endShot && !ballMoving)
            {
                for(int i = 0; i < gameManager.objectsInScene.Count; i++)
                {
                    gameManager.objectsInScene[i].GetComponent<BrickMovementController>().currentState = BrickMovementController.brickState.move;
                }
                BallsAmountText.gameObject.SetActive(true);
                BallsAmountText.gameObject.transform.position = new Vector3(ballLandingPos.x, transform.position.y - 0.5f, transform.position.z);
                BallsAmountText.text = "x" + gameManager.BallsAmount; 
                balls.Clear();
                gameManager.PlaceBricks();
                endShot = false;
            }
            coinsNumber.text = gameManager.coins.ToString();
        }
    }

    IEnumerator waitToReleaseBall()
    {
        for(int i = 1; i <= gameManager.BallsAmount; i++)
        {
            Rigidbody2D ballInstance = Instantiate(_ballPrefab, transform.position, Quaternion.identity);
            balls.Add(ballInstance);
            ballInstance.velocity = ballDirection * speed;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void ControllPlayer()
    {
        Vector3 sd = InputInstance.swipeDelta;
        sd.Set(-sd.x, -sd.y, sd.z);

        if(sd != Vector3.zero)
        {
            if(sd.y < 15f)
            {
                wrapper.parent.gameObject.SetActive(false);
            }
            else
            {
                wrapper.parent.up = sd.normalized;
                wrapper.parent.gameObject.SetActive(true);
                wrapper.localScale = Vector3.Lerp(new Vector3(1f, 1f, 1f),new Vector3(1.7f, 1.7f, 1f), sd.magnitude/maxPull);
                if(InputInstance.release == true)
                {
                    wrapper.parent.gameObject.SetActive(false);
                    ballDirection = sd.normalized;
                    _ballPrefab.simulated = true;
                    ballRelease = true;
                }
            }
        }
    }

    

}
