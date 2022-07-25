using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementJoystick : MonoBehaviour
{
    public GameObject joystick;
    public GameObject joystickBg;
    public Vector2 joystickVec;
    public Vector2 joystickTouchPos;
    public Vector2 joystickOriginalPos;

    private float joystickRadius;

    private void Start()
    {
        joystickOriginalPos = joystickBg.transform.position;
        joystickRadius = joystickBg.GetComponent<RectTransform>().sizeDelta.y;
    }

    public void PointerDown()
    {
        joystick.transform.position = Input.mousePosition;
        //joystickBg.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joystickVec = (dragPos - joystickTouchPos).normalized;

        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);

        if(joystickDist < joystickRadius)
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickDist;
        }
        else
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
        }
    }

    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        //joystickBg.transform.position = joystickOriginalPos;
    }
}
