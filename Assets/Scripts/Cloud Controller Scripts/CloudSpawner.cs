using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] clouds;
    [SerializeField]
    private GameObject[] collectables;
    private GameObject player;

    private float distanceBetweenClouds = 3f;
    private float minX;
    private float maxX;
    private float lastCloudPositionY;
    private float controlX;

    void Awake() {
        controlX = 0;

        SetMinAndMax();
        CreateClouds();

        player = GameObject.Find("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        PositionPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetMinAndMax() {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));

        maxX = bounds.x - 0.7f;
        minX = -bounds.x + 0.7f;
    }

    private void Shuffle(GameObject[] arrayToShuffle) {
        for(int i = 0; i < arrayToShuffle.Length; i++){
            int randomNum = Random.Range(i, arrayToShuffle.Length);

            GameObject temp = arrayToShuffle[i];
            arrayToShuffle[i] = arrayToShuffle[randomNum];
            arrayToShuffle[randomNum] = temp;
        }
    }

    private void CreateClouds() {
        Shuffle(clouds);

        float positionY = 0f;

        for(int i = 0; i < clouds.Length; i++) {
            Vector3 temp = clouds[i].transform.position;

            if(controlX == 0) {
                temp.x = 0.0f;
                controlX = 1;
            } else if(controlX == 1) {
                temp.x = Random.Range(0.3f, maxX);
                controlX = 2;
            } else if(controlX == 2) {
                temp.x = Random.Range(-0.3f, minX);
                controlX = 3;
            } else if(controlX == 3) {
                temp.x = Random.Range(1.0f, maxX);
                controlX = 4;
            } else if(controlX == 4) {
                temp.x = Random.Range(-1.0f, minX);
                controlX = 1;
            }

            temp.y = positionY;

            lastCloudPositionY = positionY;

            clouds[i].transform.position = temp;
            positionY -= distanceBetweenClouds;
        }
    }

    private void PositionPlayer() {

        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("DeadlyCloud");
        GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag("Cloud");

        for(int i = 0; i < darkClouds.Length; i++) {

            if(darkClouds[i].transform.position.y == 0f) {
                Vector3 tmp = darkClouds[i].transform.position;
                darkClouds[i].transform.position = new Vector3(cloudsInGame[0].transform.position.x,
                                                            cloudsInGame[0].transform.position.y,
                                                            cloudsInGame[0].transform.position.z);
                cloudsInGame[0].transform.position = tmp;
            }
        }

        Vector3 temp = cloudsInGame[0].transform.position;

        for(int i = 1; i < cloudsInGame.Length; i++) {
            if(temp.y <  cloudsInGame[i].transform.position.y) {
                temp = cloudsInGame[i].transform.position;
            }
        }

        temp.y += 1.0f;
        player.transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Cloud" || other.tag == "DeadlyCloud") {

            if(other.transform.position.y == lastCloudPositionY) {
                Shuffle(clouds);
                Shuffle(collectables);

                Vector3 temp = other.transform.position;

                for(int i = 0; i < clouds.Length; i++) {

                    if(!clouds[i].activeInHierarchy) {

                        if(controlX == 0) {
                            temp.x = 0.0f;
                            controlX = 1;
                        } else if(controlX == 1) {
                            temp.x = Random.Range(0.3f, maxX);
                            controlX = 2;
                        } else if(controlX == 2) {
                            temp.x = Random.Range(-0.3f, minX);
                            controlX = 3;
                        } else if(controlX == 3) {
                            temp.x = Random.Range(1.0f, maxX);
                            controlX = 4;
                        } else if(controlX == 4) {
                            temp.x = Random.Range(-1.0f, minX);
                            controlX = 1;
                        }

                        temp.y -= distanceBetweenClouds;
                        lastCloudPositionY = temp.y;

                        clouds[i].transform.position = temp;
                        clouds[i].SetActive(true);
                    }
                }
            }
        }
    }
}
