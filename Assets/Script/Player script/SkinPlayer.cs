using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPlayer : MonoBehaviour
{
    public float numeroskinp1 = 0;
    public float numeroskinp2 = 0;
    public float numeroskinp3 = 0;
    public float numeroskinp4 = 0;

    public Sprite[] Skin;

    public GameObject[] Player;

    public float modejeux;

    //camera
    public Camera cam;
    public Camera cam2;
    public float screencoef;
    private float vraiscreencoef;
    void Start()
    {
        numeroskinp1 = PlayerPrefs.GetFloat("numskinp1");
        numeroskinp2 = PlayerPrefs.GetFloat("numskinp2");
        numeroskinp3 = PlayerPrefs.GetFloat("numskinp3");
        numeroskinp4 = PlayerPrefs.GetFloat("numskinp4");
        modejeux = PlayerPrefs.GetFloat("PlayerScriptMode");
    }

    // Update is called once per frame
    void Update()
    {
        screencoef = (float)(Screen.width / (float)Screen.height);
        vraiscreencoef = 1.77777777777f / screencoef;

        cam2.orthographicSize = cam.orthographicSize * vraiscreencoef;


        // 0
        if (numeroskinp1 == 0)
        {
            
            if (modejeux < 3)
            {
                Player[0].SetActive(false);
            }
            else
            {
                Player[0].GetComponent<SpriteRenderer>().sprite = null;
                Player[0].GetComponent<CircleCollider2D>().isTrigger = true;
                Player[0].GetComponent<TrailRenderer>().emitting = false;
            }
            
            
            
        }
        if (numeroskinp2 == 0)
        {
            
            
            if (modejeux != 3)
            {
                Player[1].SetActive(false);
            }
            else
            {
                Player[1].GetComponent<SpriteRenderer>().sprite = null;
                Player[1].GetComponent<CircleCollider2D>().isTrigger = true;
                Player[1].GetComponent<TrailRenderer>().emitting = false;
            }




        }
        if (numeroskinp3 == 0)
        {
            if(modejeux < 3)
            {

                Player[2].SetActive(false);
            }
            else
            {
                Player[2].GetComponent<SpriteRenderer>().sprite = null;
                Player[2].GetComponent<CircleCollider2D>().isTrigger = true;
                Player[2].GetComponent<TrailRenderer>().emitting = false;
            }
                

                
            
            
        }
        if (numeroskinp4 == 0)
        {
            if (modejeux < 3)
            {
                
                Player[3].SetActive(false);
            }
            else
            {
                Player[3].GetComponent<SpriteRenderer>().sprite = null;
                Player[3].GetComponent<CircleCollider2D>().isTrigger = true;
                Player[3].GetComponent<TrailRenderer>().emitting = false;
            }

                
            
        }
        // 1
        if (numeroskinp1 == 1)
        {
            Player[0].GetComponent<SpriteRenderer>().sprite = Skin[0];
            Player[0].GetComponent<TrailRenderer>().startColor = Color.blue;
        }
        if (numeroskinp2 == 1)
        {
            Player[1].GetComponent<SpriteRenderer>().sprite = Skin[0];
            Player[1].GetComponent<TrailRenderer>().startColor = Color.blue;
        }
        if (numeroskinp3 == 1)
        {
            Player[2].GetComponent<SpriteRenderer>().sprite = Skin[0];
            Player[2].GetComponent<TrailRenderer>().startColor = Color.blue;
        }
        if (numeroskinp4 == 1)
        {
            Player[3].GetComponent<SpriteRenderer>().sprite = Skin[0];
            Player[3].GetComponent<TrailRenderer>().startColor = Color.blue;
        }
        // 2
        if (numeroskinp1 == 2)
        {
            Player[0].GetComponent<SpriteRenderer>().sprite = Skin[1];
            Player[0].GetComponent<TrailRenderer>().startColor = Color.yellow;
        }
        if (numeroskinp2 == 2)
        {
            Player[1].GetComponent<SpriteRenderer>().sprite = Skin[1];
            Player[1].GetComponent<TrailRenderer>().startColor = Color.yellow;
        }
        if (numeroskinp3 == 2)
        {
            Player[2].GetComponent<SpriteRenderer>().sprite = Skin[1];
            Player[2].GetComponent<TrailRenderer>().startColor = Color.yellow;
        }
        if (numeroskinp4 == 2)
        {
            Player[3].GetComponent<SpriteRenderer>().sprite = Skin[1];
            Player[3].GetComponent<TrailRenderer>().startColor = Color.yellow;
        }
        // 3
        if (numeroskinp1 == 3)
        {
            Player[0].GetComponent<SpriteRenderer>().sprite = Skin[2];
            Player[0].GetComponent<TrailRenderer>().startColor = Color.grey;
        }
        if (numeroskinp2 == 3)
        {
            Player[1].GetComponent<SpriteRenderer>().sprite = Skin[2];
            Player[1].GetComponent<TrailRenderer>().startColor = Color.grey;
        }
        if (numeroskinp3 == 3)
        {
            Player[2].GetComponent<SpriteRenderer>().sprite = Skin[2];
            Player[2].GetComponent<TrailRenderer>().startColor = Color.grey;
        }
        if (numeroskinp4 == 3)
        {
            Player[3].GetComponent<SpriteRenderer>().sprite = Skin[2];
            Player[3].GetComponent<TrailRenderer>().startColor = Color.grey;
        }
        //4
        if (numeroskinp1 == 4)
        {
            Player[0].GetComponent<SpriteRenderer>().sprite = Skin[3];
            Player[0].GetComponent<TrailRenderer>().startColor = new Color(0.5f, 0.2f, 0.2f);
        }
        if (numeroskinp2 == 4)
        {
            Player[1].GetComponent<SpriteRenderer>().sprite = Skin[3];
            Player[1].GetComponent<TrailRenderer>().startColor = new Color(0.5f, 0.2f, 0.2f);
        }
        if (numeroskinp3 == 4)
        {
            Player[2].GetComponent<SpriteRenderer>().sprite = Skin[3];
            Player[2].GetComponent<TrailRenderer>().startColor = new Color(0.5f, 0.2f, 0.2f);
        }
        if (numeroskinp4 == 4)
        {
            Player[3].GetComponent<SpriteRenderer>().sprite = Skin[3];
            Player[3].GetComponent<TrailRenderer>().startColor = new Color(0.5f, 0.2f, 0.2f);
        }
        //5
        if (numeroskinp1 == 5)
        {
            Player[0].GetComponent<SpriteRenderer>().sprite = Skin[4];
            Player[0].GetComponent<TrailRenderer>().startColor = Color.white;
        }
        if (numeroskinp2 == 5)
        {
            Player[1].GetComponent<SpriteRenderer>().sprite = Skin[4];
            Player[1].GetComponent<TrailRenderer>().startColor = Color.white;
        }
        if (numeroskinp3 == 5)
        {
            Player[2].GetComponent<SpriteRenderer>().sprite = Skin[4];
            Player[2].GetComponent<TrailRenderer>().startColor = Color.white;
        }
        if (numeroskinp4 == 5)
        {
            Player[3].GetComponent<SpriteRenderer>().sprite = Skin[4];
            Player[3].GetComponent<TrailRenderer>().startColor = Color.white;
        }
        //6
        if (numeroskinp1 == 6)
        {
            Player[0].GetComponent<SpriteRenderer>().sprite = Skin[5];
            Player[0].GetComponent<TrailRenderer>().startColor = new Color(0.9f, 0, 0.9f);
        }
        if (numeroskinp2 == 6)
        {
            Player[1].GetComponent<SpriteRenderer>().sprite = Skin[5];
            Player[1].GetComponent<TrailRenderer>().startColor = new Color(0.9f, 0, 0.9f);
        }
        if (numeroskinp3 == 6)
        {
            Player[2].GetComponent<SpriteRenderer>().sprite = Skin[5];
            Player[2].GetComponent<TrailRenderer>().startColor = new Color(0.9f, 0, 0.9f);
        }
        if (numeroskinp4 == 6)
        {
            Player[3].GetComponent<SpriteRenderer>().sprite = Skin[5];
            Player[3].GetComponent<TrailRenderer>().startColor = new Color(0.9f, 0, 0.9f);
        }
        //7
        if (numeroskinp1 == 7)
        {
            Player[0].GetComponent<SpriteRenderer>().sprite = Skin[6];
            Player[0].GetComponent<TrailRenderer>().startColor = Color.black;
        }
        if (numeroskinp2 == 7)
        {
            Player[1].GetComponent<SpriteRenderer>().sprite = Skin[6];
            Player[1].GetComponent<TrailRenderer>().startColor = Color.black;
        }
        if (numeroskinp3 == 7)
        {
            Player[2].GetComponent<SpriteRenderer>().sprite = Skin[6];
            Player[2].GetComponent<TrailRenderer>().startColor = Color.black;
        }
        if (numeroskinp4 == 7)
        {
            Player[3].GetComponent<SpriteRenderer>().sprite = Skin[6];
            Player[3].GetComponent<TrailRenderer>().startColor = Color.black;
        }

        //8
        if (numeroskinp1 == 8)
        {
            Player[0].GetComponent<SpriteRenderer>().sprite = Skin[7];
            Player[0].GetComponent<TrailRenderer>().startColor = Color.red;
        }
        if (numeroskinp2 == 8)
        {
            Player[1].GetComponent<SpriteRenderer>().sprite = Skin[7];
            Player[1].GetComponent<TrailRenderer>().startColor = Color.red;
        }
        if (numeroskinp3 == 8)
        {
            Player[2].GetComponent<SpriteRenderer>().sprite = Skin[7];
            Player[2].GetComponent<TrailRenderer>().startColor = Color.red;
        }
        if (numeroskinp4 == 8)
        {
            Player[3].GetComponent<SpriteRenderer>().sprite = Skin[7];
            Player[3].GetComponent<TrailRenderer>().startColor = Color.red;
        }
        //9
        if (numeroskinp1 == 9)
        {
            Player[0].GetComponent<SpriteRenderer>().sprite = Skin[8];
            Player[0].GetComponent<TrailRenderer>().startColor = Color.grey;
        }
        if (numeroskinp2 == 9)
        {
            Player[1].GetComponent<SpriteRenderer>().sprite = Skin[8];
            Player[1].GetComponent<TrailRenderer>().startColor = Color.grey;
        }
        if (numeroskinp3 == 9)
        {
            Player[2].GetComponent<SpriteRenderer>().sprite = Skin[8];
            Player[2].GetComponent<TrailRenderer>().startColor = Color.grey;
        }
        if (numeroskinp4 == 9)
        {
            Player[3].GetComponent<SpriteRenderer>().sprite = Skin[8];
            Player[3].GetComponent<TrailRenderer>().startColor = Color.grey;
        }
        //10
        if (numeroskinp1 == 10)
        {
            Player[0].GetComponent<SpriteRenderer>().sprite = Skin[9];
            Player[0].GetComponent<TrailRenderer>().startColor = Color.green;
        }
        if (numeroskinp2 == 10)
        {
            Player[1].GetComponent<SpriteRenderer>().sprite = Skin[9];
            Player[1].GetComponent<TrailRenderer>().startColor = Color.green;
        }
        if (numeroskinp3 == 10)
        {
            Player[2].GetComponent<SpriteRenderer>().sprite = Skin[9];
            Player[2].GetComponent<TrailRenderer>().startColor = Color.green;
        }
        if (numeroskinp4 == 10)
        {
            Player[3].GetComponent<SpriteRenderer>().sprite = Skin[9];
            Player[3].GetComponent<TrailRenderer>().startColor = Color.green;
        }
    }
}
