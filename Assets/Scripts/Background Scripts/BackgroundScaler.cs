using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;

        // Background Image Width
        float width = mySpriteRenderer.bounds.size.x;
        // Camera Height & Width
        float worldHeight = Camera.main.orthographicSize * 2.0f;
        float worldWidth = worldHeight / Screen.height * Screen.width;

        // Scale The Image On X axis
        tempScale.x = worldWidth / width;
        transform.localScale = tempScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
