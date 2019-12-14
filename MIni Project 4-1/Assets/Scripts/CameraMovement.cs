using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform camera;
    void Start()
    {
        //TouchControls.data += CameraSwipe;
        camera = this.transform;
    }

    public void CameraSwipe(float movement)
    {
        switch (movement)
        {
            case 0:
                //PlayerDefender.Instance.onButtonTouched = true;
                camera.transform.eulerAngles = new Vector3(0, camera.eulerAngles.y - 90, 0);
                break;
            case 1:
                //camera.transform.eulerAngles = new Vector3(0, 90, 0);
                //PlayerDefender.Instance.onButtonTouched = true;
                camera.transform.eulerAngles = new Vector3(0, camera.eulerAngles.y + 90, 0);
                break;
        }
        Debug.Log("Euler Angle is" + camera.eulerAngles.y);
        //PlayerDefender.Instance.onButtonTouched = false;
    }
}
