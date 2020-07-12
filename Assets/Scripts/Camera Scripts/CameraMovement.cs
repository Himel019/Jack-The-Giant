using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.5f;
    [SerializeField]
    private float acceleration = 0.3f;
    [SerializeField]
    private float maxSpeed = 5f;

    private bool moveCamera;

    // Start is called before the first frame update
    void Start()
    {
        moveCamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveCamera) {
            MoveCamera();
        }
    }

    private  void MoveCamera() {
        Vector3 temp = transform.position;

        float oldY = temp.y;
        float newY = temp.y - (speed * Time.deltaTime);
        temp.y = Mathf.Clamp(temp.y, oldY, newY);
        transform.position = temp;

        speed += acceleration * Time.deltaTime;

        if(speed > maxSpeed) {
            speed = maxSpeed;
        }
        maxSpeed += 0.0005f;
    }
}
