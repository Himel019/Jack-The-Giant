using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystickMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float maxSpeed = 10f;

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;

    private bool moveLeft;
    private bool moveRight;

    // Start is called before the first frame update
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(moveLeft) {
            MoveLeft();
        } 
        
        if(moveRight) {
            MoveRight();
        }
    }

    public void SetMoveDirection(bool direction)  {
        moveLeft = direction;
        moveRight = !direction;
    }

    public void StopMoving() {
        moveLeft = moveRight = false;
        myAnimator.SetBool("Walk", false);
    }

    private void MoveLeft() {
        float horizontalMoveDirection = -1f;
        Vector2 playerSpeed = new Vector2(horizontalMoveDirection * speed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerSpeed;
        Debug.Log(myRigidbody.velocity.x);

        myAnimator.SetBool("Walk", true);
        mySpriteRenderer.flipX = true;
    }

    private void MoveRight() {
        float horizontalMoveDirection = 1f;
        Vector2 playerSpeed = new Vector2(horizontalMoveDirection * speed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerSpeed;
        Debug.Log(myRigidbody.velocity.x);

        myAnimator.SetBool("Walk", true);
        mySpriteRenderer.flipX = false;
    }
}
