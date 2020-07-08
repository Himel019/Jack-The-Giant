using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float maxSpeed = 6f;

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
    }

    private void PlayerMoveKeyboard() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        Vector2 playerSpeed = new Vector2(horizontalInput * speed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerSpeed;
        
        if(horizontalInput == 1f) {
            myAnimator.SetBool("Walk", true);
            mySpriteRenderer.flipX = false;
        } else if(horizontalInput == -1f) {
            myAnimator.SetBool("Walk", true);
            mySpriteRenderer.flipX = true;
        } else {
            myAnimator.SetBool("Walk", false);
        }
        
    }
}
