using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject listPerso;
    private Vector3 persoSize;
    private float multiplie = 1;
    private bool stopit = false;
    public GameObject BoutonPlayscene3;
    private bool StartPlay;
    public GameObject[] Cadre;
    //camera
    public Camera cam;
    public Camera cam2;
    private Vector3 camdeplacement;
    private float camzoom;
    //change scene
    public GameObject Scene1;
    public GameObject Scene2;
    public GameObject Scene3;
    public GameObject QuitGameMenu;
    public GameObject OptionMenu;


    private int quitmenunum;
    private int optionmenunum;
    public int scenenumero = 1;
    private int scenemodenum = 0;
    //text
    public Text Tap;
    private bool changement = false;
    private float jsp;
    //Menu
    private bool Quit;
    private bool Option;

    
    public GameObject Bouton;
    public GameObject musicMenu;

    //Option
    private bool music = true;
    private bool son = false;
    private int musicint = 1;
    private int sonint = 1;
    public GameObject musicBar;
    public GameObject sonBar;

    public float screencoef;
    private float vraiscreencoef;

    //animation
    public GameObject gif1;
    public GameObject gif2;
    public GameObject gif3;
    void Start()
    {
        screencoef = (float)(Screen.width / (float)Screen.height);
        vraiscreencoef = 1.77777777777f / screencoef;

        camdeplacement = cam.transform.position;
        camzoom = cam.orthographicSize;
        persoSize = listPerso.transform.localScale;

        //Son
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
    public void StartGame(bool ok)
    {
        if (ok == true && sonint == 1)
        {

            Bouton.SetActive(false);
            Bouton.SetActive(true);

        }
        StartPlay = ok;
    }
    public void changescene(int scenenumber)
    {
        if (scenenumero > 1 && sonint == 1)
        {
            //AudioSource.PlayClipAtPoint(Bouton, transform.position);
            Bouton.SetActive(false);
            Bouton.SetActive(true);
        }
        scenenumero = scenenumber;
    }

    public void chargegame(int modenum)
    {
        if (modenum > 0 && sonint == 1)
        {
            //AudioSource.PlayClipAtPoint(Bouton, transform.position);
            Bouton.SetActive(false);
            Bouton.SetActive(true);
        }
        scenemodenum = modenum;
    }

    public void QuitMenu(int quitnum)
    {
        if (quitnum > 0 && sonint == 1)
        {
            //AudioSource.PlayClipAtPoint(Bouton, transform.position);
            Bouton.SetActive(false);
            Bouton.SetActive(true);
        }
        quitmenunum = quitnum;
    }

    public void OptionMen(int optionnum)
    {
        if (optionnum > 0 && sonint == 1 && optionnum != 3)
        {
            //AudioSource.PlayClipAtPoint(Bouton, transform.position);
            Bouton.SetActive(false);
            Bouton.SetActive(true);
        }
        if (optionnum == 3 && sonint == 0)
        {
            Bouton.SetActive(false);
            Bouton.SetActive(true);
        }
        optionmenunum = optionnum;
    }

    void Update()
    {
        

        musicint = PlayerPrefs.GetInt("Music");
        sonint = PlayerPrefs.GetInt("Son");
        if (optionmenunum == 1)
        {
            OptionMenu.SetActive(true);
            Option = true;
        }
        if (optionmenunum == 2)
        {
            if (music == false && optionmenunum == 2)
            {
                music = true;
                optionmenunum = 0;
            }
            if (music == true && optionmenunum == 2)
            {
                music = false;
                optionmenunum = 0;
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
            musicMenu.SetActive(true);
        }
        if (musicint == 0)
        {
            //music off
            musicMenu.SetActive(false);
        }

        if (optionmenunum == 3)
        {
            if (son == false && optionmenunum == 3)
            {
                son = true;
                optionmenunum = 0;
            }
            if (son == true && optionmenunum == 3)
            {
                son = false;
                optionmenunum = 0;
            }
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

        if (optionmenunum == 4)
        {
            OptionMenu.SetActive(false);
            Option = false;
            optionmenunum = 0;
        }


        if (quitmenunum == 1)
        {
            QuitGameMenu.SetActive(false);
            Quit = false;
            quitmenunum = 0;
        }
        if (quitmenunum == 2)
        {
            Application.Quit();
            quitmenunum = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && scenenumero == 1 && Option == true)
        {
            optionmenunum = 4;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && scenenumero == 1 && Quit == true && Option == false)
        {
            quitmenunum = 1;
        }


        if (Input.GetKeyDown(KeyCode.Escape) && scenenumero == 1 && Option == false && Quit == false)
        {
            QuitGameMenu.SetActive(true);
            Quit = true;
        }
        if(Input.GetKeyDown(KeyCode.Escape) && scenenumero == 2)
        {
            scenenumero = 1;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && scenenumero == 3)
        {
            scenenumero = 2;
        }


        if (scenenumero == 1)
        {
            if(camdeplacement.y > -3.63f)
            {
                camdeplacement.y -= Time.deltaTime * 5;
            }
            else
            {
                camdeplacement.y = -3.63f;
            }
            if(camzoom < 10)
            {
                camzoom += Time.deltaTime * 6;
            }
            else
            {
                camzoom = 10;
            }
            if (camdeplacement.y == -3.63f && camzoom == 10)
            {
                Scene1.SetActive(true);
            }
            Scene2.SetActive(false);
            Scene3.SetActive(false);

            cam.transform.localPosition = camdeplacement;
            cam.orthographicSize = camzoom;
            cam2.orthographicSize = camzoom * vraiscreencoef;
            cam2.transform.localPosition = camdeplacement;
        }
        if (scenenumero == 2)
        {

            Scene1.SetActive(false);
            Scene3.SetActive(false);
            //deplacement camera
            if (camdeplacement.y < 0.5f)
            {
               camdeplacement.y += Time.deltaTime * 5;
                
            }
            else
            {
                camdeplacement.y = 0.5f;
            }
            //zoom camera
            if (camzoom > 4.5f)
            {
                camzoom -= Time.deltaTime *6;
            }
            else
            {
                camzoom = 4.5f;
            }
            if (camzoom == 4.5f && camdeplacement.y == 0.5f)
            {
                Scene2.SetActive(true);
                persoSize.x += Time.deltaTime * multiplie * 0.5f;
                persoSize.y += Time.deltaTime * multiplie * 0.5f;
                if (persoSize.x >= 1.25)
                {
                    multiplie = -1;
                    stopit = true;
                }

                if (stopit == true && persoSize.x <= 1)
                {
                    persoSize.x = 1;
                    persoSize.y = 1;
                }
            }
            listPerso.transform.localScale = persoSize;
            cam.transform.localPosition = camdeplacement;
            cam.orthographicSize = camzoom;
            cam2.orthographicSize = camzoom * vraiscreencoef; //5.63
            cam2.transform.localPosition = camdeplacement;
            

        }
        if (scenenumero == 3)
        {
            Scene1.SetActive(false);
            Scene2.SetActive(false);
            Scene3.SetActive(true);
            cam2.orthographicSize = cam.orthographicSize * vraiscreencoef;
        }




        //Transparence Tapez pour jouer
        Tap.color = new Color(0, 0, 0, jsp);
        if (jsp >= 1)
        {
            jsp = 1;
            changement = true;
        }
        if(jsp < 0)
        {
            jsp = 0;
            changement = false;
        }
        if (changement == false)
        {
            jsp += Time.deltaTime  ;
        }
        else
        {
            jsp -= Time.deltaTime ;
        }
        //$
        if (scenemodenum != 0)
        {
            
        }
        if (scenemodenum == 1 && StartPlay == false)
        {
            gif1.SetActive(true);
            gif2.SetActive(false);
            gif3.SetActive(false);


            BoutonPlayscene3.SetActive(true);
            Cadre[0].SetActive(true);
            Cadre[1].SetActive(false);
            Cadre[2].SetActive(false);
        }

        if (scenemodenum == 2 && StartPlay == false)
        {
            gif1.SetActive(false);
            gif2.SetActive(true);
            gif3.SetActive(false);


            Cadre[1].SetActive(true);
            Cadre[0].SetActive(false);
            Cadre[2].SetActive(false);
            BoutonPlayscene3.SetActive(true);
        }

        if (scenemodenum == 3 && StartPlay == false)
        {
            gif1.SetActive(false);
            gif2.SetActive(false);
            gif3.SetActive(true);


            Cadre[2].SetActive(true);
            Cadre[1].SetActive(false);
            Cadre[0].SetActive(false);
            BoutonPlayscene3.SetActive(true);
        }




        if (scenemodenum == 1 && StartPlay == true)
        {
            SceneManager.LoadScene("Rumble");
            PlayerPrefs.SetFloat("PlayerScriptMode", scenemodenum);
        }
        if (scenemodenum == 2 && StartPlay == true)
        {
            SceneManager.LoadScene("ModeTron");
            PlayerPrefs.SetFloat("PlayerScriptMode", scenemodenum);
        }
        if (scenemodenum == 3 && StartPlay == true)
        {
            SceneManager.LoadScene("Bomb");
            PlayerPrefs.SetFloat("PlayerScriptMode", scenemodenum);
        }



        if (PlayerPrefs.GetInt("Menu") == 1)
        {
            
            scenenumero = 3;
            camdeplacement.y = 0.5f;
            camzoom = 4.5f;
            cam.transform.localPosition = camdeplacement;
            cam.orthographicSize = camzoom;
            cam2.orthographicSize = cam.orthographicSize * vraiscreencoef;
            cam2.transform.localPosition = camdeplacement;
            PlayerPrefs.SetInt("Menu", 0);
            
        }
    }
}
