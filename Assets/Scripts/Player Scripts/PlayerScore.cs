using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinClip, lifeClip;

    private CameraMovement cameraScript;

    private Vector3 previousPosition;
    private bool countScore;

    public static int scoreCount;
    public static int lifeCount;
    public static int coinCount;

    void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
        countScore = true;
    }

    // Update is called once per frame
    void Update()
    {
        CountScore();
    }

    private void CountScore() {
        if(countScore) {
            if(transform.position.y < previousPosition.y) {
                scoreCount++;
            }
            previousPosition = transform.position;
            GameplayController.instance.SetScore(scoreCount);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Coin") {
            coinCount++;
            scoreCount += 200;

            GameplayController.instance.SetScore(scoreCount);
            GameplayController.instance.SetCoinScore(coinCount);

            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            other.gameObject.SetActive(false);
        } else if(other.tag == "Life") {
            lifeCount++;
            scoreCount += 200;

            GameplayController.instance.SetScore(scoreCount);
            GameplayController.instance.SetLifeScore(lifeCount);
            
            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            other.gameObject.SetActive(false);
        } else if(other.tag == "Bounds" || other.tag == "DeadlyCloud") {
            cameraScript.IsCameraMoving(false);
            countScore = false;

            transform.position = new Vector3(500f, 500f, 0);
            lifeCount--;

            GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
        }
    }
}
