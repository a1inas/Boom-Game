using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    Vector3 touchStart;
    public float maxZoom;
    public float minZoom;
    public float sensitivity = 1;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector3 direction = touchStart - GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            GetComponent<Camera>().transform.position += direction;
        }

        ZoomCamera(Input.GetAxis("Mouse ScrollWheel"));

        if (Input.GetKey(KeyCode.Equals) || Input.GetKey(KeyCode.KeypadPlus))
        {
            ZoomCamera(0.1f);
        }
        if (Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.KeypadMinus))
        {
            ZoomCamera(-0.1f);
        }
    }

    void ZoomCamera(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment * sensitivity, minZoom, maxZoom);
    }
}