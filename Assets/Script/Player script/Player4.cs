using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player4 : MonoBehaviour
{
    public Rigidbody2D rb2dj2;

    //Joystick
    Vector2 directionJoystick;
    public VariableJoystick JoystickP1;


    //Dash
    public float TimerDashCd;
    private float TimerDash;
    public float DashTimerCd;
    private float DashTimer; //temps avant de pouvoir redasher

    //death
    private bool death = false;
    private float deathTimer = 0;
    public float deathTimerCd;

    //vitesse
    public float vitessemax;
    public float acceleration = 0.25f;
    public float AccelerationTimeCd;


    //rotation
    public float vitesseRotationj1;
    bool rotationtruej1 = false;
    bool rotationdroite = false;
    private float rotationVitesse = 1.25f;
    private float rotationVitesseTimer;
    public float rotationVitesseTimerCD;
    bool rotationfaitesj1 = false;
    private float Timerotation = 0;
    public float TimerotationCD; // temps avant de retourner

    bool dashrbzero;

    //UI
    private bool avanceButton = false;

    //Hit
    public float TimerHit;

    //direction
    Vector3 direction;

    //victoire
    public WinnerPlayer winner;
    private Vector3 Positionbase;
    public MoveText move;


    // UI dash
    public Sprite okDash;
    public Sprite noDash;
    public Image dashokoupas;
    private float dashtime;

    //mode de jeu 
    float modeDeJeu;


    //mode de jeu 2
    float angle;
    public bool traildeath;
    public ParticleSystem particle;

    //mode de jeu 3
    public bool drapeau = false;
    private float vitessem3 = 18.5f;
    public GameObject Gdrapeau;
    private float respawnTime;

    //Pause
    public bool Pausem;

    //music
    public GameObject SonGame;
    void Start()
    {


        Positionbase = transform.position;
        modeDeJeu = PlayerPrefs.GetFloat("PlayerScriptMode");

        if (PlayerPrefs.GetFloat("numskinp4") == 0)
        {
            winner.isDeath[3] = true;
            particle.Pause();

        }

    }




    //
    void Update()
    {

        if (winner.winner == true)
        {
            particle.Pause();
            particle.Clear();
        }
        // 1 Classique 

        if (modeDeJeu == 1)
        {
            //joystick
            //dash
            if (DashTimer > 0 && Pausem == false)
            {
                DashTimer -= Time.deltaTime;
            }
            if (move.all == true || (JoystickP1.dash == true && DashTimer > 0))
            {
                JoystickP1.dash = false;
            }
            if (JoystickP1.dash == true && DashTimer <= 0 && Pausem == false && move.all == false)
            {
                directionJoystick = JoystickP1.dashdir; //dir dash
                if (directionJoystick.x < 0.4f && directionJoystick.x > -0.4f && directionJoystick.y < 0.4f && directionJoystick.y > -0.4f)//Il ne se passe rien
                {
                    JoystickP1.dash = false;
                }
                else
                {
                    if (dashrbzero == false)
                    {
                        dashtime = 0;
                        rb2dj2.velocity = Vector2.zero; //0,0
                        dashrbzero = true;
                    }
                    if (TimerDash <= TimerDashCd)
                    {


                        rotationtruej1 = false; //tourne pas
                        vitesseRotationj1 = Mathf.Atan2(-directionJoystick.x, directionJoystick.y) * Mathf.Rad2Deg; //rotation joueur en direction du joystick
                        rb2dj2.transform.rotation = Quaternion.Euler(Vector3.forward * vitesseRotationj1);
                        rb2dj2.AddForce(directionJoystick * 2, ForceMode2D.Impulse);//40 remplacable par la puissance
                                                                                    //rb2dj2.velocity = directionJoystick * 10;

                        TimerDash += Time.deltaTime;
                    }
                    else
                    {
                        TimerDash = 0;
                        rotationVitesse = 0.5f;
                        rotationtruej1 = true; //tourne
                        DashTimer = DashTimerCd;//temps avant de redash
                        dashrbzero = false;
                        JoystickP1.dash = false;
                    }
                }
            }
            //

            //Button
            if (JoystickP1.avance == true)

            {
                avanceButton = true;
            }
            else
            {
                avanceButton = false;
            }
            //
            //dash
            if (JoystickP1.dash == false && dashtime < DashTimerCd && Pausem == false)
            {
                dashtime += Time.deltaTime;
                dashokoupas.GetComponent<Image>().sprite = noDash;
            }
            else if (JoystickP1.dash == false && dashtime >= DashTimerCd)
            {
                dashokoupas.GetComponent<Image>().sprite = okDash;
            }
            //
            //


            //rotation player

            if (Pausem == false && rotationtruej1 == true || move.turn == true)
            {
                if (rotationVitesseTimer < rotationVitesseTimerCD)
                {
                    rotationVitesseTimer += Time.deltaTime;
                }
                else
                {
                    if (rotationVitesse < 2)  //2.335f
                    {
                        rotationVitesse += Time.deltaTime * 2f;//4
                    }
                    if (rotationVitesse > 2)
                    {
                        rotationVitesse = 2;
                    }
                    if (rotationdroite == true)//tourne a droite
                    {
                        vitesseRotationj1 -= Time.deltaTime * 144 * rotationVitesse;
                    }
                    else//tourne a gauche
                    {
                        vitesseRotationj1 += Time.deltaTime * 144 * rotationVitesse;
                    }
                    rb2dj2.transform.rotation = Quaternion.Euler(Vector3.forward * vitesseRotationj1);
                }


            }
            //

            //Hit
            if (TimerHit > 0)
            {
                TimerHit -= Time.deltaTime * 3;
            }
            //

            //avance
            if (move.all == false)
            {

                if (Input.GetKey(KeyCode.H) || avanceButton == true)
                {
                    gameObject.GetComponent<TrailRenderer>().enabled = true;

                    direction = transform.up; //direction

                    //rotation
                    Timerotation = 0;

                    rotationVitesseTimer = 0;

                    rotationVitesse = 0.4f; //1.75f

                    rotationtruej1 = false;

                    rotationfaitesj1 = false;

                    //avancer
                    if (TimerHit <= 0)
                    {
                        rb2dj2.AddForce(direction * vitessemax * 1);
                    }
                    //
                }
                else
                {





                    //rotation
                    if (Timerotation <= TimerotationCD)
                    {
                        Timerotation += Time.deltaTime;
                    }
                    else
                    {
                        rotationtruej1 = true;
                    }


                    //droite ou gauche
                    if (rotationdroite == false && rotationfaitesj1 == false)
                    {
                        rotationdroite = true;

                        rotationfaitesj1 = true;
                    }
                    else if (rotationdroite == true && rotationfaitesj1 == false)
                    {
                        rotationdroite = false;

                        rotationfaitesj1 = true;
                    }
                    //
                }
            }
        }




        //2 tron


        if (modeDeJeu == 2 || modeDeJeu == 3)
        {
            if (Pausem == true)
            {
                particle.Pause();
                rotationtruej1 = true;//bool rien a voir
            }
            else if (Pausem == false && rotationtruej1 == true)
            {
                particle.Play();
                rotationtruej1 = false;
            }
            if (JoystickP1.ok == true)
            {
                angle = Mathf.Atan2(-JoystickP1.input.x, JoystickP1.input.y) * Mathf.Rad2Deg;
            }
            else
            {
                if (angle == 0)
                {
                    angle = 180;
                }
                else if (angle != 0 && angle != 180 && angle != -135)
                {
                    angle = Mathf.Atan2(-JoystickP1.dashdir.x, JoystickP1.dashdir.y) * Mathf.Rad2Deg;
                }
            }
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            if (Pausem == true || (move.all == false && winner.isDeath[3] == false))
            {
                GetComponent<TrailRenderer>().enabled = true;
                if (modeDeJeu == 2)
                {
                    rb2dj2.AddForce(transform.up * 20);
                }
                particle.gameObject.SetActive(true);
            }
            else
            {
                GetComponent<TrailRenderer>().enabled = false;
                particle.gameObject.SetActive(false);
            }
        }

        //mode de jeu 3
        if (modeDeJeu == 3)
        {
            if (winner.isDeath[3] == true)
            {
                if (respawnTime <= 2 && Pausem == false)
                {
                    respawnTime += Time.deltaTime;
                }
                if (respawnTime > 1 && respawnTime <= 2)
                {
                    death = false;
                    gameObject.GetComponent<CircleCollider2D>().enabled = true;
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    gameObject.GetComponent<TrailRenderer>().enabled = false;
                    gameObject.GetComponent<TrailRenderer>().Clear();
                    rb2dj2.velocity = Vector2.zero;
                    transform.eulerAngles = new Vector3(0, 0, -135);
                    angle = -135;
                    gameObject.transform.position = Positionbase;
                }
                if (respawnTime > 2)
                {
                    death = false;
                    winner.isDeath[3] = false;
                    respawnTime = 0;
                }

            }



            if (TimerHit > 0)
            {
                TimerHit -= Time.deltaTime;
            }
            if (Pausem == true || (move.all == false && winner.isDeath[3] == false))
            {
                rb2dj2.AddForce(transform.up * vitessem3);
            }
            if (drapeau == true)
            {
                vitessem3 = 16;
                winner.drapeaujoueur[3] = true;
                gameObject.transform.localScale = new Vector3(0.8f, 0.8f, transform.localScale.z);
            }
            else
            {
                winner.drapeaujoueur[3] = false;
                vitessem3 = 21;
                gameObject.transform.localScale = new Vector3(0.55f, 0.55f, transform.localScale.z);
            }


        }








        if (traildeath == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<TrailRenderer>().enabled = false;
            winner.isDeath[3] = true;
            traildeath = false;

        }

        //Mort du joueur
        if (death == true && Pausem == false)
        {
            if (deathTimer < deathTimerCd)
            {
                deathTimer += Time.deltaTime;

            }
            else
            {
                if (modeDeJeu != 3 && winner.isDeath[3] == false && winner.isDeath[1] == true && winner.isDeath[2] == true && winner.isDeath[0] == true)
                {
                }
                else
                {
                    if (modeDeJeu == 3 && drapeau == true)
                    {
                        Gdrapeau.SetActive(true);
                        Gdrapeau.transform.position = new Vector3(1, 2.15f, 0);
                        drapeau = false;
                    }
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    gameObject.GetComponent<CircleCollider2D>().enabled = false;
                    gameObject.GetComponent<TrailRenderer>().enabled = false;
                    winner.isDeath[3] = true;


                }


            }
        }
        if (move.turn == false && (winner.restart[3] == true || move.all))
        {
            particle.gameObject.SetActive(false);
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<TrailRenderer>().enabled = false;
            gameObject.GetComponent<TrailRenderer>().Clear();
            avanceButton = false;
            rotationtruej1 = false;
            vitesseRotationj1 = -135;
            rotationVitesse = 1;
            transform.eulerAngles = new Vector3(0, 0, -135);
            rb2dj2.velocity = Vector2.zero;
            angle = -135;
            gameObject.transform.position = Positionbase;
            winner.isDeath[3] = false;
            winner.restart[3] = false;

        }
        if (move.turn == true)
        {
            rotationtruej1 = true;
            rotationfaitesj1 = true;
            rotationdroite = true;
        }
        if (winner.isDeath[3] == false && winner.isDeath[1] == true && winner.isDeath[2] == true && winner.isDeath[0] == true)
        {
            avanceButton = false;
            JoystickP1.dash = false;
            DashTimer = 5;
        }






    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //sound
        if (other.gameObject.tag == "Player1" && PlayerPrefs.GetInt("Son") == 1)
        {
            SonGame.SetActive(false);
            SonGame.SetActive(true);
        }
        if (other.gameObject.tag == "Player2" && PlayerPrefs.GetInt("Son") == 1)
        {
            SonGame.SetActive(false);
            SonGame.SetActive(true);
        }
        if (other.gameObject.tag == "Player3" && PlayerPrefs.GetInt("Son") == 1)
        {
            SonGame.SetActive(false);
            SonGame.SetActive(true);
        }








        if (modeDeJeu == 3)
        {
            if (drapeau == false)
            {
                if (other.gameObject.tag == "Player1" && FindObjectOfType<Player1re>().drapeau == true && FindObjectOfType<Player1re>().TimerHit <= 0 && TimerHit <= 0)
                {
                    
                    drapeau = true;
                    FindObjectOfType<Player1re>().drapeau = false;
                    TimerHit = 0.1f;
                }
                if (other.gameObject.tag == "Player3" && FindObjectOfType<Player3>().drapeau == true && FindObjectOfType<Player3>().TimerHit <= 0 && TimerHit <= 0)
                {
                    
                    drapeau = true;
                    FindObjectOfType<Player3>().drapeau = false;
                    TimerHit = 0.1f;
                }
                if (other.gameObject.tag == "Player2" && FindObjectOfType<Player2re>().drapeau == true && FindObjectOfType<Player2re>().TimerHit <= 0 && TimerHit <= 0)
                {
                    
                    drapeau = true;
                    FindObjectOfType<Player2re>().drapeau = false;
                    TimerHit = 0.1f;

                }
            }

        }
    }




    //voir si le player sort de la map
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Map"))
        {
            Debug.Log("mapexit");
            death = true;
        }
    }


    //voir si le player revient sur la map
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Map")
        {
            Debug.Log("Mapenter");
            death = false;
            deathTimer = 0;
        }
        if (other.tag == "Drapeau")
        {
            if (FindObjectOfType<Player2re>().drapeau == false && FindObjectOfType<Player3>().drapeau == false && FindObjectOfType<Player1re>().drapeau == false)
            {
                drapeau = true;
                other.gameObject.SetActive(false);
            }
        }
            
    }
}
