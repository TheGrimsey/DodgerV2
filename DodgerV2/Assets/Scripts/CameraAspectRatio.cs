using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspectRatio : MonoBehaviour
{
    public float targetAspectRatio = 16f / 9f;

    // Start is called before the first frame update
    void Start()
    {
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspectRatio;
        Camera camera = GetComponent<Camera>();

        if (scaleHeight < 1.0f)
        {
            camera.orthographicSize = camera.orthographicSize / scaleHeight;
        }
    }

}
