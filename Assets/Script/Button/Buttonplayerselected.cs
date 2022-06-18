using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Buttonplayerselected : MonoBehaviour,IDragHandler
{
    public SelectionPlayer select;
    private Vector3 publictransform;
    private bool appuyer = false; // si tu appuie
    public bool onCercle; //si est dans le rond
    Vector3 positionbase; // position de basse
    public float numero;
    private GameObject game;

    public void appuie(bool appuioupas)
    {
        appuyer = appuioupas;
    }

    void Start()
    {
        positionbase = new Vector3(transform.position.x, transform.position.y, 0);
    }
   
    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = eventData.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (appuyer == false && onCercle == false)
        {
            publictransform = transform.position;
            if (transform.position != positionbase)
            {
                if (publictransform.x < positionbase.x + 50 && publictransform.x > positionbase.x - 50)
                {
                    publictransform.x = positionbase.x;
                }
                else if (Mathf.Round(publictransform.x) > Mathf.Round(positionbase.x))
                {
                    publictransform.x -= Mathf.Round(Time.deltaTime * 6000);
                }
                else if (Mathf.Round(publictransform.x) < Mathf.Round(positionbase.x))
                {
                    publictransform.x += Mathf.Round(Time.deltaTime * 6000);
                }

                if (publictransform.y < positionbase.y + 50 && publictransform.y > positionbase.y - 50)
                {
                    publictransform.y = positionbase.y;
                }
                else if (publictransform.y > positionbase.y)
                {
                    publictransform.y -= Mathf.Round(Time.deltaTime * 6000);
                }

                else if (publictransform.y < positionbase.y)
                {
                    publictransform.y += Mathf.Round(Time.deltaTime * 6000);
                }
                transform.position = publictransform;
            }
            
        }
        if (onCercle == true && appuyer == false)
        {
            if (select.numskinp1 == numero)
            {
                transform.position = select.buttons[0].transform.position;
                select.pose[0] = true;
            }
            if (select.numskinp2 == numero)
            {
                transform.position = select.buttons[1].transform.position;
                select.pose[1] = true;
            }
            if (select.numskinp3 == numero)
            {
                transform.position = select.buttons[2].transform.position;
                select.pose[2] = true;
            }
            if (select.numskinp4 == numero)
            {
                transform.position = select.buttons[3].transform.position;
                select.pose[3] = true;
            }
        }
        
        
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1")
        {
            if (select.numskinp1 == 0 )
            {
                onCercle = true;
                select.numskinp1 = numero;
            }
            
        }
        if (other.gameObject.tag == "Player2")
        {
            if (select.numskinp2 == 0)
            {
                onCercle = true;
                select.numskinp2 = numero;
            }

        }
        if (other.gameObject.tag == "Player3")
        {
            if (select.numskinp3 == 0)
            {
                onCercle = true;
                select.numskinp3 = numero;
            }

        }
        if (other.gameObject.tag == "Player4")
        {
            if (select.numskinp4 == 0)
            {
                onCercle = true;
                select.numskinp4 = numero;
            }
        }
    }
     void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1")
        {
            if (select.numskinp1 == numero)
            {
                onCercle = false;
                select.numskinp1 = 0;
                select.pose[0] = false;
            }
            
        }
        if (other.gameObject.tag == "Player2")
        {
            if (select.numskinp2 == numero)
            {
                onCercle = false;
                select.numskinp2 = 0;
                select.pose[1] = false;
            }    
        }
        if (other.gameObject.tag == "Player3")
        {
            if (select.numskinp3 == numero)
            {
                onCercle = false;
                select.numskinp3 = 0;
                select.pose[2] = false;
            }
        }
        if (other.gameObject.tag == "Player4")
        {
            if (select.numskinp4 == numero)
            {
                onCercle = false;
                select.numskinp4 = 0;
                select.pose[3] = false;
            }

        }
    }
    
}
