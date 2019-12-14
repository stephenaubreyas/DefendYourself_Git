using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeLogger : MonoBehaviour
{
    //private LineRenderer lineRenderer;

    private void Awake()
    {
        //lineRenderer = GetComponent<LineRenderer>();
        TouchControls.tData += SwipeData;
        //TouchControls.data += DrawLine;
    }
   

    void SwipeData(TouchMovement movement)
    {
        Debug.Log("Position is " + movement.swipeControls);
    }

    //void DrawLine(SwipeMovement movement)
    //{
    //    var x = Camera.main.ScreenToWorldPoint(new Vector3(movement.StartPos.x, movement.StartPos.y, 10));
    //    var y = Camera.main.ScreenToWorldPoint(new Vector3(movement.endPos.x, movement.endPos.y, 10));

    //    lineRenderer.SetPosition(0, x);
    //    lineRenderer.SetPosition(1, y);
    //}
}
