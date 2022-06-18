using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemcolor : MonoBehaviour
{
    public ParticleSystem[] particleplayer;
    private Player1re player1;
    private Player2re player2;
    private Player3 player3;
    private Player4 player4;

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
        if (PlayerPrefs.GetFloat("numskinp1") != 0)
        {
            particleplayer[0].startColor = player1.GetComponent<TrailRenderer>().startColor;
        }
        if (PlayerPrefs.GetFloat("numskinp2") != 0)
        {
            particleplayer[1].startColor = player2.GetComponent<TrailRenderer>().startColor;
        }
        if (PlayerPrefs.GetFloat("numskinp3") != 0)
        {
            particleplayer[2].startColor = player3.GetComponent<TrailRenderer>().startColor;
        }
        if (PlayerPrefs.GetFloat("numskinp4") != 0)
        {
            particleplayer[3].startColor = player4.GetComponent<TrailRenderer>().startColor;
        }
    }
}
