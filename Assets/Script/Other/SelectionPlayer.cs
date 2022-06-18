using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectionPlayer : MonoBehaviour
{
    private int numberplayerselect;
    public float numskinp1;
    public float numskinp2;
    public float numskinp3;
    public float numskinp4;

    public Button[] buttons;
    public Button StartButton;
    public bool[] pose;
    public int[] how;


    public GameObject buttonreturn2;
    private Vector3 butonreturnstartpos;
    void Start()
    {
        butonreturnstartpos = buttonreturn2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //1
        if (numskinp1 != 0 && pose[0] == true)
        {
            how[0] = 1;
        }
        else
        {
            how[0] = 0;
        }
        //2
        if (numskinp2 != 0 && pose[1] == true)
        {
            how[1] = 1;
        }
        else
        {
            how[1] = 0;
        }
        //3
        if (numskinp3 != 0 && pose[2] == true)
        {
            how[2] = 1;
        }
        else
        {
            how[2] = 0;
        }
        //4
        if (numskinp4 != 0 && pose[3] == true)
        {
            how[3] = 1;
        }
        else
        {
            how[3] = 0;
        }



        if (how[0] + how[1]+ how[2]+ how[3] >= 2)
        {
            buttonreturn2.transform.position = new Vector3(butonreturnstartpos.x, buttonreturn2.transform.position.y, buttonreturn2.transform.position.z);
            StartButton.gameObject.SetActive(true);
            PlayerPrefs.SetFloat("numskinp1", numskinp1);
            PlayerPrefs.SetFloat("numskinp2", numskinp2);
            PlayerPrefs.SetFloat("numskinp3", numskinp3);
            PlayerPrefs.SetFloat("numskinp4", numskinp4);
        }
        else
        {
            buttonreturn2.transform.position = new Vector3(butonreturnstartpos.x + 150 , buttonreturn2.transform.position.y, buttonreturn2.transform.position.z);
            StartButton.gameObject.SetActive(false);
        }
    }
}
