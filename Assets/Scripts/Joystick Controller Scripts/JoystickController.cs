using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class JoystickController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerJoystickMovement playerMove;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerJoystickMovement>();
    }

    public void OnPointerDown(PointerEventData data) {
        if(gameObject.name == "Left Joystick") {
            playerMove.SetMoveDirection(true);
        } else {
            playerMove.SetMoveDirection(false);
        }
    }

    public void OnPointerUp(PointerEventData data) {
        playerMove.StopMoving();
    }
}
