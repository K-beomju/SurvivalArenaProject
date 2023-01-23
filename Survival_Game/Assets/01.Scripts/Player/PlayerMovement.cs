using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private MovementJoystick movementJoystick;
    [SerializeField] private float playerSpeed;

    private Rigidbody2D rb;
    private PlayerAnimation playerAnim;
    private PlayerAttack playerAk;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimation>();
        playerAk = GetComponent<PlayerAttack>();
    }

    private void FixedUpdate()
    {
        rb.velocity = movementJoystick.joystickVec.y != 0 ? rb.velocity 
        = new Vector2(movementJoystick.joystickVec.x * playerSpeed, 
        movementJoystick.joystickVec.y * playerSpeed) : rb.velocity = Vector2.zero;
        
        playerAnim.SetDirection(Vector2.ClampMagnitude(rb.velocity, 1));
    }

}
