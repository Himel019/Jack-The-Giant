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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
