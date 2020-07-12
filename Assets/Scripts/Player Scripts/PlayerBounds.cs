using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private float minX;
    private float maxX;

    // Start is called before the first frame update
    void Start()
    {
        SetMinXAndMaxX();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        
        if(transform.position.x < minX) {
            temp.x = minX;
            transform.position = temp;
        } else if(transform.position.x > maxX) {
            temp.x = maxX;
            transform.position = temp;
        }
    }

    private void SetMinXAndMaxX() {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }
}
