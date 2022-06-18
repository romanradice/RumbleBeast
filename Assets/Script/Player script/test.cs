using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private float timer;
    private Player1re player1;
    private Player2re player2;
    private Player3 player3;
    private Player4 player4;

    public float player;
    // Start is called before the first frame update
    void Start()
    {
        player1 = FindObjectOfType<Player1re>();
        player2 = FindObjectOfType<Player2re>();
        player3 = FindObjectOfType<Player3>();
        player4 = FindObjectOfType<Player4>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 2.5f )
        {
            if (player1 != null)
            {
                if (player1.Pausem == false){
                    timer += Time.deltaTime;
                }
            }
            else if (player2 != null)
            {
                if (player2.Pausem == false)
                {
                    timer += Time.deltaTime;
                }
            }
            else if (player3 != null)
            {
                if (player3.Pausem == false)
                {
                    timer += Time.deltaTime;
                }
            }
            else if (player4 != null)
            {
                if (player4.Pausem == false)
                {
                    timer += Time.deltaTime;
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
        if (PlayerPrefs.GetFloat("numskinp1") != 0)
        {
            
            if (player1.winner.isDeath[0] == true && player == 1)
            {
                Destroy(gameObject);
            }
        }
        if (PlayerPrefs.GetFloat("numskinp2") != 0)
        {
            if (player2.winner.isDeath[1] == true && player == 2)
            {
                Destroy(gameObject);
            }
        }

        if (PlayerPrefs.GetFloat("numskinp3") != 0)
        {
            if (player2.winner.isDeath[2] == true && player == 3)
            {
                Destroy(gameObject);
            }
        }

        if (PlayerPrefs.GetFloat("numskinp4") != 0)
        {
            if (player4.winner.isDeath[3] == true && player == 4)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //p1
        if (other.tag == "Player1tron" && timer > 0.5f && player == 1)
        {
            player1.traildeath = true;
        }
        if(other.tag == "Player1tron" && player != 1)
        {
            player1.traildeath = true;
        }

        //p2
        if (other.tag == "Player2tron" && timer > 0.5f && player == 2 )
        {
            player2.traildeath = true;
        }
        if (other.tag == "Player2tron" && player != 2)
        {
            
            player2.traildeath = true;
        }

        //p3
        if (other.tag == "Player3tron" && timer > 0.5f && player == 3 )
        {
            player3.traildeath = true;
        }
        if (other.tag == "Player3tron" && player != 3)
        {
            player3.traildeath = true;
        }

        //p4
        if (other.tag == "Player4tron" && timer > 0.5f && player == 4)
        {
            player4.traildeath = true;
        }
        if (other.tag == "Player4tron" && player != 4)
        {
            player4.traildeath = true;
        }
    }
}
