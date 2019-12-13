using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwipeControls
{
    None, Touch, Left, Right
}

public struct SwipeMovement
{
    public Vector3 StartPos;

    public Vector3 endPos;

    public SwipeControls swipeControls;
}

public struct TouchMovement
{
    public Vector3 StartPos;

    public SwipeControls swipeControls;
}

public class TouchControls : MonoBehaviour
{
    public Vector3 startPosition;

    public Vector3 endPosition;

    public static event Action<SwipeMovement> data;
    public static event Action<TouchMovement> tData;

    public bool afterSwiping;


    void MouseTouch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            endPosition = Input.mousePosition;
            CheckTouch();
        }
        if (!afterSwiping && Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
            CheckSwipe();
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPosition = Input.mousePosition;
            CheckSwipe();
        }
    }

    void TouchControl()
    {
        if (Input.touchCount > 0)
        {
            foreach (var touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    startPosition = touch.position;
                    endPosition = touch.position;
                    CheckTouch();
                }
                if (!afterSwiping && touch.phase == TouchPhase.Moved)
                {
                    endPosition = touch.position;
                    CheckSwipe();
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    endPosition = touch.position;
                    CheckSwipe();
                }
            }
        }
    }

    private void Update()
    {
        TouchControl();
        MouseTouch();
    }

    public void CheckSwipe()
    {
        if (CheckMinDistance())
        {
            if (DetectHorizontalSwipe())
            {
                SendSwipeDirections();
            }
        }
    }
    public void CheckTouch()
    {
        if (CheckTouchDistance())
        {
            SendTouchDirections();
        }
    }


    public float HorizontalDistance()
    {
        return Mathf.Abs(endPosition.x - startPosition.x);
    }

    public bool CheckMinDistance()
    {
        return HorizontalDistance() > 15;
    }

    public bool CheckTouchDistance()
    {
        return HorizontalDistance() < 5;
    }

    public bool DetectHorizontalSwipe()
    {
        return HorizontalDistance() > VerticalDistance();
    }

    //public bool DetectTouch()
    //{
    //    return HorizontalDistance() < VerticalDistance();
    //}

    public void SendSwipeDirections()
    {
        var dir = endPosition.x - startPosition.x > 0 ? SwipeControls.Right : SwipeControls.Left;

        SetData(dir);
    }

    public void SendTouchDirections()
    {
        var dir = SwipeControls.Touch;

        SetTouchData(dir);
    }

    public float VerticalDistance()
    {
        return Mathf.Abs(endPosition.y - startPosition.y);
    }

    public void SetData(SwipeControls controls)
    {
        SwipeMovement swipeData = new SwipeMovement
        {
            StartPos = startPosition,
            endPos = endPosition,
            swipeControls = controls
        };

        data?.Invoke(swipeData);
    }

    public void SetTouchData(SwipeControls controls)
    {
        TouchMovement swipeData = new TouchMovement
        {
            StartPos = startPosition,
            swipeControls = controls
        };

        tData?.Invoke(swipeData);
    }
}
