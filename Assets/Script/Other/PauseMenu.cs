using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private WinnerPlayer winner;
    public GameObject PausedMenu;
    private int buttonnum;
    bool pause;

    private Player1re player1;
    private Player2re player2;
    private Player3 player3;
    private Player4 player4;

    //music
    private bool music = false;
    private bool son = false;
    private int musicint;
    private int sonint;
    public GameObject SonGame;
    public GameObject musicGame;
    public GameObject musicBar;
    public GameObject sonBar;

    void Start()
    {
        player1 = FindObjectOfType<Player1re>();
        player2 = FindObjectOfType<Player2re>();
        player3 = FindObjectOfType<Player3>();
        player4 = FindObjectOfType<Player4>();

        winner = FindObjectOfType<WinnerPlayer>();
        PausedMenu.SetActive(false);

        //music
        if (PlayerPrefs.GetInt("Son") == 1)
        {
            son = true;
        }
        else
        {
            son = false;
        }
        //music
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            music = true;
        }
        else
        {
            music = false;
        }
    }

    public void PausMenu(int num)
    {
        if (num > 0 && sonint == 1 && num != 2)
        {
            SonGame.SetActive(false);
            SonGame.SetActive(true);
        }
        if (num == 2 && sonint == 0)
        {
            SonGame.SetActive(false);
            SonGame.SetActive(true);
        }
        buttonnum = num;
    }



    void Update()
    {
        musicint = PlayerPrefs.GetInt("Music");
        sonint = PlayerPrefs.GetInt("Son");
        
        //pause
        if (Input.GetKeyDown(KeyCode.Escape) && pause == true)
        {
            buttonnum = 3;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && winner.winner == false && pause == false)
        {
            PausedMenu.SetActive(true);
            pause = true;
        }
        

        player1.Pausem = pause;
        player2.Pausem = pause;
        player3.Pausem = pause;
        player4.Pausem = pause;

        if (pause == true || winner.winner == true)
        {
            player1.rb2dj2.constraints = RigidbodyConstraints2D.FreezeAll;
            player2.rb2dj2.constraints = RigidbodyConstraints2D.FreezeAll;
            player3.rb2dj2.constraints = RigidbodyConstraints2D.FreezeAll;
            player4.rb2dj2.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else if (pause == false && winner.winner == false)
        {
            player1.rb2dj2.constraints = RigidbodyConstraints2D.None;
            player2.rb2dj2.constraints = RigidbodyConstraints2D.None;
            player3.rb2dj2.constraints = RigidbodyConstraints2D.None;
            player4.rb2dj2.constraints = RigidbodyConstraints2D.None;
        }

        //////////////////////////////////////////////////////////////////
        if (buttonnum == 1)
        {
            if (music == false && buttonnum == 1)
            {
                music = true;
                buttonnum = 0;
            }
            if (music == true && buttonnum == 1)
            {
                music = false;
                buttonnum = 0;
            }
        }
        if (music == true)
        {
            musicBar.SetActive(false);
            PlayerPrefs.SetInt("Music", 1);
        }
        else
        {
            musicBar.SetActive(true);
            PlayerPrefs.SetInt("Music", 0);
        }

        if (musicint == 1)
        {
            //music on
            musicGame.SetActive(true);
        }
        if (musicint == 0)
        {
            //music off
            musicGame.SetActive(false);
        }
        /////////////////////////////////////////////////////////////////////
        ///
        if (son == false && buttonnum == 2)
        {
            son = true;
            buttonnum = 0;
        }
        if (son == true && buttonnum == 2)
        {
            son = false;
            buttonnum = 0;
        }
    
        if (son == true)
        {
            sonBar.SetActive(false);
            PlayerPrefs.SetInt("Son", 1);
        }
        else
        {
            sonBar.SetActive(true);
            PlayerPrefs.SetInt("Son", 0);
        }
        ////////////////////////////////////////////////////////////////////////
        if (buttonnum == 3)
        {
            PausedMenu.SetActive(false);
            pause = false;
            buttonnum = 0;
        }
        if (buttonnum == 4)
        {
            winner.pauserestart = true;
            PausedMenu.SetActive(false);
            pause = false;
            buttonnum = 0;
        }
        if (buttonnum == 5)
        {
            winner.choicesur = 1;
            
        }
        

    }
}
