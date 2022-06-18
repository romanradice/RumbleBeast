using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    private float StartTimer = 3;
    public bool TimerOk = true;
    private float curringtime;
    public Text TimerG;
    private float TimerGo = 0;
    // Start is called before the first frame update
    void Start()
    {
        curringtime = StartTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOk == true)
        {
            curringtime -= Time.deltaTime;
            TimerG.text = curringtime.ToString("0");

            if (curringtime <= 0.5f)
            {
                TimerGo += Time.deltaTime;
                TimerG.text = "Go";
            }
            if (TimerGo > 1)
            {
                TimerG.text = "";
                TimerGo = 0;
                curringtime = 0.5f;
                TimerOk = false;
            }
        }
        
    }
}
