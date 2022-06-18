using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class WinnerPlayer : MonoBehaviour
{
    public SkinPlayer skin;
    public int[] nomberplayeringame;
    private int playerchiffres;
    public bool[] isDeath;

    private float victoirej1;
    private float victoirej2;
    private float victoirej3;
    private float victoirej4;

    public bool[] restart;
    public bool winner;

    private Timer timer;
    private int round = 1;

    public Text textwinner;
    public GameObject winnerplay;

    public int choicesur;
    bool nochoice;
    private bool victoirego = false;
    public bool reset;
    public bool pauserestart;

    public TextMeshProUGUI text;
    public MoveText move;

    public TextMeshProUGUI j1score;
    public TextMeshProUGUI j2score;
    public TextMeshProUGUI j3score;
    public TextMeshProUGUI j4score;

    public GameObject winnerj1;
    public GameObject winnerj2;
    public GameObject winnerj3;
    public GameObject winnerj4;

    public GameObject menurestart;


    public GameObject[] dashlist;
    public GameObject[] Joysticklist;


    private Menu menu;

    public bool[] drapeaujoueur;

    public GameObject Drap;

    public GameObject BoutonSon;

    private int Pubnum;
    private int Pubnumcd;
    private bool pubunefois;

    private Pub pub;
    // Start is called before the first frame update
    void Start()
    {
        Pubnum = PlayerPrefs.GetInt("cpub");
        pub = FindObjectOfType<Pub>();
        menu = FindObjectOfType<Menu>();
    }
    // Update is called once per frame
    public void restartmenu(int choice)
    {
        if (choice > 0)
        {
            BoutonSon.SetActive(false);
            BoutonSon.SetActive(true);
        }
        choicesur = choice;
    }
    void Update()
    {
        if (drapeaujoueur[0] == true && victoirej1 <= 5 && victoirej2 <= 5 && victoirej3 <= 5 && victoirej4 <= 5 && FindObjectOfType<Player1re>().Pausem == false)
        {
            victoirej1 += 0.6f * Time.deltaTime;
        }

        if (drapeaujoueur[1] == true && victoirej1 <= 5 && victoirej2 <= 5 && victoirej3 <= 5 && victoirej4 <= 5 && FindObjectOfType<Player2re>().Pausem == false)
        {
            victoirej2 += 0.6f * Time.deltaTime;
        }
        if (drapeaujoueur[2] == true && victoirej1 <= 5 && victoirej2 <= 5 && victoirej3 <= 5 && victoirej4 <= 5 && FindObjectOfType<Player3>().Pausem == false)
        {
            victoirej3 += 0.6f * Time.deltaTime;
        }
        if (drapeaujoueur[3] == true && victoirej1 <= 5 && victoirej2 <= 5 && victoirej3 <= 5 && victoirej4 <= 5 && FindObjectOfType<Player4>().Pausem == false)
        {
            victoirej4 += 0.6f * Time.deltaTime;
        }







        //j1
        if (skin.numeroskinp1 != 0)
        {

            if (PlayerPrefs.GetFloat("PlayerScriptMode") == 3)
            {
                j1score.text = victoirej1.ToString("0.0");
            }
            else
            {
                j1score.text = victoirej1.ToString();
            }
        }
        else
        {
            j1score.text = "";
            isDeath[0] = true;
            dashlist[0].SetActive(false);
            Joysticklist[0].SetActive(false);
        }
        //j2
        if (skin.numeroskinp2 != 0)
        {
            if (PlayerPrefs.GetFloat("PlayerScriptMode") == 3)
            {
                j2score.text = victoirej2.ToString("0.0");
            }
            else
            {
                j2score.text = victoirej2.ToString();
            }
        }
        else
        {
            j2score.text = "";
            isDeath[1] = true;
            dashlist[1].SetActive(false);
            Joysticklist[1].SetActive(false);
        }
        //j3
        if (skin.numeroskinp3 != 0)
        {
            if (PlayerPrefs.GetFloat("PlayerScriptMode") == 3)
            {
                j3score.text = victoirej3.ToString("0.0");
            }
            else
            {
                j3score.text = victoirej3.ToString();
            }
        }
        else
        {
            j3score.text = "";
            isDeath[2] = true;
            dashlist[2].SetActive(false);
            Joysticklist[2].SetActive(false);
        }
        //j4
        if (skin.numeroskinp4 != 0)
        {
            if (PlayerPrefs.GetFloat("PlayerScriptMode") == 3)
            {
                j4score.text = victoirej4.ToString("0.0");
            }
            else
            {
                j4score.text = victoirej4.ToString();
            }
        }
        else
        {
            j4score.text = "";
            isDeath[3] = true;
            dashlist[3].SetActive(false);
            Joysticklist[3].SetActive(false);
        }


        //choicesur
        if (choicesur == 1)
        {
            Pubnumcd = 1;
            Pubnum += Pubnumcd;
            Pubnumcd = 0;
            PlayerPrefs.SetInt("cpub", Pubnum);
            PlayerPrefs.SetInt("Menu", 1);
            SceneManager.LoadScene("Menu");
        }
        if (choicesur == 2 || pauserestart == true)
        {
            winner = false;
            reset = true;
            menurestart.SetActive(false);
            round = 1;
            victoirej1 = 0;
            victoirej2 = 0;
            victoirej3 = 0;
            victoirej4 = 0;
            pauserestart = false;

            if (PlayerPrefs.GetFloat("PlayerScriptMode") == 3)
            {
                Drap.SetActive(true);
                Drap.transform.position = new Vector3(1, 2.15f, 0);
                FindObjectOfType<Player1re>().drapeau = false;
                FindObjectOfType<Player2re>().drapeau = false;
                FindObjectOfType<Player3>().drapeau = false;
                FindObjectOfType<Player4>().drapeau = false;
            }

            if (skin.numeroskinp1 != 0)
            {
                restart[0] = true;
                isDeath[0] = false;
            }
            if (skin.numeroskinp2 != 0)
            {
                restart[1] = true;
                isDeath[1] = false;
            }
            if (skin.numeroskinp3 != 0)
            {
                restart[2] = true;
                isDeath[2] = false;
            }
            if (skin.numeroskinp4 != 0)
            {
                restart[3] = true;
                isDeath[3] = false;
            }


            winnerplay.SetActive(true);
            move.ok = true;
            move.go = false;
            move.all = true;
            text.text = "Manche : " + round;

            pubunefois = false;
            Pubnumcd = 1;
        }
        //1win

        if (PlayerPrefs.GetFloat("PlayerScriptMode") != 3 && isDeath[0] == false && isDeath[1] == true && isDeath[2] == true && isDeath[3] == true && victoirej1 < 5 && victoirej2 < 5 && victoirej3 < 5 && victoirej4 < 5)
        {
            if (victoirego == true)
            {
                round += 1;
                victoirej1 += 1;
                victoirego = false;
            }
            
            winnerplay.SetActive(true);
            if (move.all == false)
            {
                move.ok = true;
                move.go = false;
                move.all = true;
                text.text = "Manche : " + round;
            }
            else
            {
                reset = true;
                text.text = "Manche : " + round;
            }
            

            if (skin.numeroskinp1 != 0)
            {
                isDeath[0] = false;
                restart[0] = true;
            }
            if (skin.numeroskinp2 != 0)
            {
                isDeath[1] = false;
                restart[1] = true;
            }
            if (skin.numeroskinp3 != 0)
            {
                isDeath[2] = false;
                restart[2] = true;
            }
            if (skin.numeroskinp4 != 0)
            {
                isDeath[3] = false;
                restart[3] = true;
            }




        }
        //2win
        else if (PlayerPrefs.GetFloat("PlayerScriptMode") != 3 && isDeath[1] == false && isDeath[0] == true && isDeath[2] == true && isDeath[3] == true && victoirej1 < 5 && victoirej2 < 5 && victoirej3 < 5 && victoirej4 < 5)
        {
            if (victoirego == true)
            {
                round += 1;
                victoirej2 += 1;
                victoirego = false;
            }
            winnerplay.SetActive(true);
            if (move.all == false)
            {
                move.ok = true;
                move.go = false;
                move.all = true;
                text.text = "Manche : " + round;
            }
            else
            {
                reset = true;
                text.text = "Manche : " + round;
            }
            if (skin.numeroskinp1 != 0)
            {
                isDeath[0] = false;
                restart[0] = true;
            }
            if (skin.numeroskinp2 != 0)
            {
                isDeath[1] = false;
                restart[1] = true;
            }
            if (skin.numeroskinp3 != 0)
            {
                isDeath[2] = false;
                restart[2] = true;
            }
            if (skin.numeroskinp4 != 0)
            {
                isDeath[3] = false;
                restart[3] = true;
            }
        }
        //3win
        else if (PlayerPrefs.GetFloat("PlayerScriptMode") != 3 && isDeath[2] == false && isDeath[1] == true && isDeath[0] == true && isDeath[3] == true && victoirej1 < 5 && victoirej2 < 5 && victoirej3 < 5 && victoirej4 < 5)
        {
            if (victoirego == true)
            {
                round += 1;
                victoirej3 += 1;
                victoirego = false;
            }
            winnerplay.SetActive(true);
            if (move.all == false)
            {
                move.ok = true;
                move.go = false;
                move.all = true;
                text.text = "Manche : " + round;
            }
            else
            {
                reset = true;
                text.text = "Manche : " + round;
            }
            if (skin.numeroskinp1 != 0)
            {
                isDeath[0] = false;
                restart[0] = true;
            }
            if (skin.numeroskinp2 != 0)
            {
                isDeath[1] = false;
                restart[1] = true;
            }
            if (skin.numeroskinp3 != 0)
            {
                isDeath[2] = false;
                restart[2] = true;
            }
            if (skin.numeroskinp4 != 0)
            {
                isDeath[3] = false;
                restart[3] = true;
            }
        }
        //4win
        else if (PlayerPrefs.GetFloat("PlayerScriptMode") != 3 && isDeath[3] == false && isDeath[1] == true && isDeath[2] == true && isDeath[0] == true && victoirej1 < 5 && victoirej2 < 5 && victoirej3 < 5 && victoirej4 < 5)
        {
            if (victoirego == true)
            {
                round += 1;
                victoirej4 += 1;
                victoirego = false;
            }
            winnerplay.SetActive(true);
            if (move.all == false)
            {
                move.ok = true;
                move.go = false;
                move.all = true;
                text.text = "Manche : " + round;
            }
            else
            {
                reset = true;
                text.text = "Manche : " + round;
            }
            if (skin.numeroskinp1 != 0)
            {
                isDeath[0] = false;
                restart[0] = true;
            }
            if (skin.numeroskinp2 != 0)
            {
                isDeath[1] = false;
                restart[1] = true;
            }
            if (skin.numeroskinp3 != 0)
            {
                isDeath[2] = false;
                restart[2] = true;
            }
            if (skin.numeroskinp4 != 0)
            {
                isDeath[3] = false;
                restart[3] = true;
            }
        }
        
        else
        {
            choicesur = 0;
            victoirego = true;
        }
        if (victoirej1 >= 5 || victoirej2 >= 5 || victoirej3 >= 5 || victoirej4 >= 5)
        {
            Pubnum += Pubnumcd;
            PlayerPrefs.SetInt("cpub",Pubnum);
            Pubnumcd = 0;
            if (Pubnum % 2 == 0 && pubunefois == false)
            {
                pub.goPub = true;
                pubunefois = true;
            }
            winner = true;

            move.all = false;
            restart[0] = false;
            restart[1] = false;
            restart[2] = false;
            restart[3] = false;
            isDeath[0] = false;
            isDeath[1] = false;
            isDeath[2] = false;
            isDeath[3] = false;
            menurestart.SetActive(true);
            //1


            if (victoirej1 >= victoirej2 && victoirej1 >= victoirej3 && victoirej1 >= victoirej4)
            {
                winnerj1.SetActive(true);
            }
            else
            {
                winnerj1.SetActive(false);
            }
            //2
            if (victoirej2 >= victoirej1 && victoirej2 >= victoirej3 && victoirej2 >= victoirej4)
            {
                winnerj2.SetActive(true);
            }
            else
            {
                winnerj2.SetActive(false);
            }
            //3
            if (victoirej3 >= victoirej2 && victoirej3 >= victoirej1 && victoirej3 >= victoirej4)
            {
                winnerj3.SetActive(true);
            }
            else
            {
                winnerj3.SetActive(false);
            }
            //4
            if (victoirej4 >= victoirej1 && victoirej4 >= victoirej3 && victoirej4 >= victoirej2)
            {
                winnerj4.SetActive(true);
            }
            else
            {
                winnerj4.SetActive(false);
            }
        }
    }
}
