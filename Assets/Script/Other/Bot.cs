using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    private float vitesseRotationj1;
    public Rigidbody2D rb2d;
    void Start()
    {
        
    }

    
    void Update()
    {
        vitesseRotationj1 += Time.deltaTime * 144 * 2;
        rb2d.transform.rotation = Quaternion.Euler(Vector3.forward * vitesseRotationj1);

    }
}
