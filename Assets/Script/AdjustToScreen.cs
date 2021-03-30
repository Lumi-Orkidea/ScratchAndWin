using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Original Code from stackExchange https://gamedev.stackexchange.com/questions/167317/scale-camera-to-fit-screen-size-unity
//Modified by me
[ExecuteInEditMode]
public class AdjustToScreen : MonoBehaviour
{
    public float sceneWidth = 10;
    private Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Adjust the camera's height so the desired scene width fits in view
    // even if the screen/window size changes dynamically.
    void Update()
    {
        float unitsPerPixel = sceneWidth / Screen.width;

        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;

        GetComponent<Camera>().orthographicSize = desiredHalfHeight;
    }
}
