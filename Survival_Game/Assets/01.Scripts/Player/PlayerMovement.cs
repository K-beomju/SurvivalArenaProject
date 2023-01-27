using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private MovementJoystick movementJoystick;
    [SerializeField] private float playerSpeed;

    private Rigidbody2D rb;
    private IPlayerAnimation IplayerAnim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        IplayerAnim = GetComponent<IPlayerAnimation>();
        GameManager.instance.ph.OnDeath += () => 
        { 
            playerSpeed = 0; 
            rb.velocity = Vector2.zero;
        };

    }

    private void Update() 
    {
        LockScreenCamera();
    }

    private void FixedUpdate()
    {
        if (GameManager.IsPlayerDead()) return;

        rb.velocity = movementJoystick.joystickVec.y != 0 ? rb.velocity
        = new Vector2(movementJoystick.joystickVec.x * playerSpeed,
        movementJoystick.joystickVec.y * playerSpeed) : rb.velocity = Vector2.zero;

        IplayerAnim.SetDirection(Vector2.ClampMagnitude(rb.velocity, 1));
    }


    public void LockScreenCamera()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y > 1f) pos.y = 1f;
        if (pos.y < 0f) pos.y = 0f;

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

}
