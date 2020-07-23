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

    private float easySpeed = 4.5f;
    private float mediumSpeed = 5f;
    private float hardSpeed = 5.4f;

    private bool moveCamera;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPreferences.GetEasyDifficultyState() == 1) {
            maxSpeed = easySpeed;
        }

        if(PlayerPreferences.GetMediumDifficultyState() == 1) {
            maxSpeed = mediumSpeed;
        }

        if(PlayerPreferences.GetHardDifficultyState() == 1) {
            maxSpeed = hardSpeed;
        }

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
        maxSpeed += 0.00005f;
    }

    public void IsCameraMoving(bool value) {
        moveCamera = value;
    }
}
