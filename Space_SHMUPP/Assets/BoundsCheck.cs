using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// Keeps a GameObject on screen by checking its renderer bounds and repositioning it if it goes offscreen.
/// Note: This script only works for an orthographic camera. If you are using a perspective camera, you will need to modify the code to account for the camera's field of view and distance from the object.
/// </summary>



public class BoundsCheck : MonoBehaviour
{
    public float camWidth;
    public float camHeight;
    public enum eType { center, inset, outset };
    public eType boundsType = eType.center;
    public float radius = 1f;

    void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }


    // Start is called before the first frame update
    void Start()
        {
        
        }



    // LateUpdate is called after all Update functions have been called. This is useful for order of execution.
    void LateUpdate()
    {
        float checkRadius = 0;
        if (boundsType == eType.inset)
        {
            checkRadius = -radius;
        }
        if (boundsType == eType.outset)
        {
            checkRadius = radius;
        }

        Vector3 pos = transform.position;
        if(pos.x > camWidth + checkRadius)
        {
            pos.x = camWidth + checkRadius;
        }
        if(pos.x < -camWidth - checkRadius)
        {
            pos.x = -camWidth - checkRadius;
        }
        if (pos.y > camHeight + checkRadius)
        {
            pos.y = camHeight + checkRadius;
        }
        if (pos.y < -camHeight - checkRadius)
        {
            pos.y = -camHeight - checkRadius;
        }
        transform.position = pos;
    }

    
    
}
