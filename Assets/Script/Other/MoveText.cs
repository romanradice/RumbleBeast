using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveText : MonoBehaviour
{
    public GameObject Manche;
    public TextMeshProUGUI text;
    Vector3 moveManche;
    public bool ok = true;
    float timerok;
    public bool go;
    public bool all = true;
    public bool turn = false;
    private WinnerPlayer winner;
    // Start is called before the first frame update

    void Start()
    {
        winner = FindObjectOfType<WinnerPlayer>();
        moveManche = Manche.transform.localScale;
        text.text = "Manche 1";
        all = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (winner.reset == true)
        {
            //reset
            all = false;
            timerok = 0;
            turn = false;
            ok = true;
            go = false;
            moveManche =new Vector3(0,0,1);
            Manche.transform.localScale = moveManche;

            all = true;
            winner.reset = false;
        }
        if (all == true )
        {
            if (Manche.transform.localScale.x < 1.25f && ok == true)
            {
                moveManche.x += Time.deltaTime * 1;
                moveManche.y += Time.deltaTime * 1;
            }
            if (Manche.transform.localScale.x >= 1.25f && ok == true)
            {
                moveManche.x = 1.25f;
                moveManche.y = 1.25f;
                if (text.text == "GO!")
                {
                    go = true;
                }
                if (timerok < 0.5f)
                {
                    timerok += Time.deltaTime;
                }
                else
                {
                    ok = false;
                    timerok = 0;
                }


            }
            if (ok == false && Manche.transform.localScale.x > 0)
            {
                moveManche.x -= Time.deltaTime * 2;
                moveManche.y -= Time.deltaTime * 2;

                if (text.text == "GO!" && go == true)
                {
                    moveManche.x -= Time.deltaTime * 4;
                    moveManche.y -= Time.deltaTime * 4;
                }

            }
            if (ok == false && Manche.transform.localScale.x <= 0 && go == true)
            {
                moveManche.x = 0;
                moveManche.y = 0;
                turn = false;
                all = false;
            }

            if (ok == false && Manche.transform.localScale.x <= 0.5f && go == false)
            {
                moveManche.x = 1;
                moveManche.y = 1;
                turn = true;
                if (text.text != "GO!")
                {
                    text.text = "GO!";
                    ok = true;
                }

            }
        }
        
       
        Manche.transform.localScale = moveManche;
    }
}
