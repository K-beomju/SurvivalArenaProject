using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementJoystick : MonoBehaviour
{
    [SerializeField] private GameObject joystick;
    [SerializeField] private GameObject joystickBG;

    public Vector2 joystickVec { get; set; }

    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    
    private float joystickRadius;

    private void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 3;
        //ActiveJoystick(false);
    }

    public void PointerDown()
    {
        joystick.transform.position = Input.mousePosition;
        joystickBG.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
        ActiveJoystick(true);
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joystickVec = (dragPos - joystickTouchPos).normalized;

        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);

        if (joystickDist < joystickRadius)
            joystick.transform.position = joystickTouchPos + joystickVec * joystickDist;
        else
            joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;

    }

    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;
        //ActiveJoystick(false);
    }

    public void ActiveJoystick(bool isActive)
    {
        joystick.SetActive(isActive);
        joystickBG.SetActive(isActive);
    }


}
