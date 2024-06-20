/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TouchScript : MonoBehaviour
{
    [SerializeField] private Collider2D myTouchCollider;

    private Touch thisTouch;
    private bool isTouched;
    private bool touchValid;

    float tapTemp = 0;


    private ItouchControl beControl;
    private Vector2 touchPosition;



    void Awake()
    {
        if (gameObject.GetComponent<ItouchControl>() != null)
        {
            beControl = gameObject.GetComponent<ItouchControl>();
        }
        touchValid = true;
    }

    void Update()
    {
        if (Input.touchCount > 0 && touchValid == true)
        {
            thisTouch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(thisTouch.position);

            ///////////////////////////////////////////// START TOUCH ////////////////////////////////////////////////
            if (thisTouch.phase == TouchPhase.Began)
            {
                Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition,64);

                if (myTouchCollider == touchCollider && touchValid == true)
                {
                    isTouched = true;
                    tapTemp = 0;
                    ////// ©I¥s interface //////
                    beControl.BeganTouch();
                }
            }

            ////////////////////////////////////////////// TOUCHING //////////////////////////////////////////////////
            else if (thisTouch.phase == TouchPhase.Stationary || thisTouch.phase == TouchPhase.Moved)
            {
                if (isTouched == true)
                {
                    tapTemp += Time.deltaTime;

                    Vector2 temp = new Vector2();
                    if (touchPosition.x >= Settings.playerConfinementMinX && touchPosition.x <= Settings.playerConfinementMaxX)
                    {
                        temp.x = touchPosition.x;
                    }
                    else if (touchPosition.x < Settings.playerConfinementMinX)
                    {
                        temp.x = Settings.playerConfinementMinX;
                    }
                    else if (touchPosition.x > Settings.playerConfinementMaxX)
                    {
                        temp.x = Settings.playerConfinementMaxX;
                    }
                    if (touchPosition.y >= Settings.playerConfinementMinY && touchPosition.y <= Settings.playerConfinementMaxY)
                    {
                        temp.y = touchPosition.y;
                    }
                    else if (touchPosition.y < Settings.playerConfinementMinY)
                    {
                        temp.y = Settings.playerConfinementMinY;
                    }
                    else if (touchPosition.y > Settings.playerConfinementMaxY)
                    {
                        temp.y = Settings.playerConfinementMaxY;
                    }
                    ////// ©I¥s interface //////
                    beControl.Touching(temp);
                }
            }

            ////////////////////////////////////////////// END TOUCH /////////////////////////////////////////////////
            else if (thisTouch.phase == TouchPhase.Ended)
            {
                if (isTouched == true)
                {
                    if (tapTemp < Settings.tapThreshold)
                    {
                        ////// ©I¥s interface //////
                        beControl.EndTouch_Tap();
                    }
                    else
                    {
                        ////// ©I¥s interface //////
                        beControl.EndTouch_Hold();
                    }
                }
                isTouched = false;
            }
        }
    }
}
*/