using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Particlesystem : MonoBehaviour
{
    public GameObject gO;
    private GameObject clone;
    private float timer;
    private float Timerinstantiate;
    private Player1re player1;
    private Player2re player2;
    private Player3 player3;
    private Player4 player4;
    public int player;
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
        if (Timerinstantiate < 0.05f )
        {
            Timerinstantiate += Time.deltaTime;
        }
        else if (Timerinstantiate >= 0.05f && player1.move.all == false && player == 1 && player1.Pausem == false)
        {
            clone = Instantiate(gO, transform.position, transform.rotation);
            clone.AddComponent<test>().player = 1;
            Timerinstantiate = 0;
        }
        else if (Timerinstantiate >= 0.05f && player2.move.all == false && player == 2 && player2.Pausem == false)
        {
            clone = Instantiate(gO, transform.position, transform.rotation);
            clone.AddComponent<test>().player = 2;
            Timerinstantiate = 0;
        }
        else if (Timerinstantiate >= 0.05f && player3.move.all == false && player == 3 && player3.Pausem == false)
        {
            clone = Instantiate(gO, transform.position, transform.rotation);
            clone.AddComponent<test>().player = 3;
            Timerinstantiate = 0;
        }
        else if (Timerinstantiate >= 0.05f && player4.move.all == false && player == 4 && player4.Pausem == false)
        {
            clone = Instantiate(gO, transform.position, transform.rotation);
            clone.AddComponent<test>().player = 4;
            Timerinstantiate = 0;
        }

    }

    
}
    
