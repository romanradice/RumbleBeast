using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camtest : MonoBehaviour
{

    const float KEEP_ASPECT = 16 / 9f;

    void Start()
    {
        
            
            Camera cam = GetComponent<Camera>();
            float aspectRatio = Screen.width / ((float)Screen.height);
            float percentage = 1 - (aspectRatio / KEEP_ASPECT);
            cam.rect = new Rect(0f, (percentage / 2), 1f, (1 - percentage));
            
            
        
    }
}
