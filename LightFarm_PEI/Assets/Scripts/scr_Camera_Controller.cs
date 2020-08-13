using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Camera_Controller : MonoBehaviour
{
    Vector3 dragOrigin;

   
    public float zoomOutMin = 1;
    public float zoomOutMax = 10;

    private void Update()
    {

        //0 is left mouse button, but also references the first touch input on a device.
        //this if statement is only true at the start of the touch.
        if (Input.GetMouseButtonDown(0))
         {
            dragOrigin = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            dragOrigin = Camera.main.ScreenToWorldPoint(dragOrigin);
         }

        // this if statement is used entirely for pinch to zooming on mobile. Takes 2 points first and 2nd touch and measures the distance between fingers, if the distance gets bigger than it zooms in if it gets smaller then it zooms out.
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);
        }else if (Input.GetMouseButton(0))
        {
            Vector3 currentPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            currentPos = Camera.main.ScreenToWorldPoint(currentPos);
            Vector3 movePos = dragOrigin - currentPos;
            transform.position = transform.position + movePos;
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void zoom ( float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }






}
