using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour,IPlayerAnimation
{
    public static readonly string[] staticDirections = { "Static N", "Static W", "Static S", "Static E" };
    public static readonly string[] runDirections = { "Run N", "Run W", "Run S", "Run E" };

    private Animator anim;
    private int lastDirection;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 direction)
    {
        string[] directionArray = null;


        if (direction.magnitude < .01f)
        {
            directionArray = staticDirections;
        }
        else
        {
            directionArray = runDirections;
            lastDirection = DirectionToIndex(direction, 4);
        }
        anim.Play(directionArray[lastDirection]);

    }

    public static int DirectionToIndex(Vector2 dir, int sliceCount)
    {
        Vector2 normDir = dir.normalized;

        float step = 360f / sliceCount;

        float halfstep = step / 2;

        float angle = Vector2.SignedAngle(Vector2.up, normDir);

        angle += halfstep;

        if (angle < 0)
            angle += 360;

        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }

    public void DieAnimation()
    {
        anim.SetTrigger("Die");
    }

}
