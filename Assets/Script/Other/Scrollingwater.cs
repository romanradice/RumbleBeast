using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrollingwater : MonoBehaviour
{
    public Transform transform;
    private Vector2 Avance;
    public Vector2 Avancevalue;
    
    private bool ok;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 10 && ok == true)
        {
            Avance.x += Time.deltaTime * Avancevalue.x;
            Avance.y += Time.deltaTime * Avancevalue.y;
        }
        else
        {
            ok = true;
            Avance.x += Time.deltaTime * -Avancevalue.x;
            Avance.y += Time.deltaTime * -Avancevalue.y;
            if (ok == true && transform.position.y > -10)
            {
                ok = false;
            }
        }
        transform.position = new Vector3(Avance.x, Avance.y, 0);

    }
}
