using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D Body;
    [SerializeField]
    private SpawnManager SM;
    [SerializeField]
    private GameObject GameOver, VictoryScreen, TooManySoldierScreen;
    [SerializeField]
    private float Radius;

    public bool EndGame, GameReset, GameWon;
    public AudioSource HeliSound;

    Animator HeliAnim;

    //public bool GameWon;
    //public bool GameReset;
    public float MovementSpeed;
    public Vector2 MoveDirection;
    public LayerMask layerMask;
    public GameObject[] Soldiers;

    public DropoffSound Dropoff;
    public PickupSound Pickup;
    

    void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
        HeliSound = GetComponent<AudioSource>();
        HeliAnim = GetComponent<Animator>();

        SM = GameObject.FindObjectOfType<SpawnManager>();

        EndGame = false;
        GameReset = false;
    }

    void Update()
    {
        if (!EndGame && !GameWon)
        {
            Inputs();
            CountSoldiers();
            Collider2D HitCollider = Physics2D.OverlapCircle(transform.position, Radius, layerMask);

            if (!GameOver)
            {
                GameOver = GameObject.FindGameObjectWithTag("GameOverScreen");
            }
            else if (GameOver)
            {
                GameOver.SetActive(false);
            }
            if(!VictoryScreen)
            {
                VictoryScreen = GameObject.FindGameObjectWithTag("VictoryScreen");
            }
            else if(VictoryScreen)
            {
                VictoryScreen.SetActive(false);
            }
            if(!TooManySoldierScreen)
            {
                TooManySoldierScreen = GameObject.FindGameObjectWithTag("SoldierFull");
            }
            else if(TooManySoldierScreen)
            {
                TooManySoldierScreen.SetActive(false);
            }
            if(!Dropoff)
            {
                Dropoff = GameObject.FindObjectOfType<DropoffSound>();
            }
            if(!Pickup)
            {
                Pickup = GameObject.FindObjectOfType<PickupSound>();
            }

            if (HitCollider != null && HitCollider?.tag == "Hospital" && GameManager.Instance.SoldierCounter > 0)
            {
                //Dropoff.Play();
                if(!GameWon)
                {
                    Dropoff.Dropoff.Play();
                }
                GameManager.Instance.RescuedCounter += GameManager.Instance.SoldierCounter;
                GameManager.Instance.SoldierCounter = 0;
            }
            if (HitCollider?.tag == "InjuredSoldier" && GameManager.Instance.SoldierCounter < 3)
            {
                //Pickup.Play();
                Pickup.Pickup.Play();
                Destroy(HitCollider.gameObject);
                GameManager.Instance.SoldierCounter++;
            }
            else if (HitCollider?.tag == "InjuredSoldier" && GameManager.Instance.SoldierCounter >= 3)
            {
                TooManySoldierScreen.SetActive(true);
            }
            if(HitCollider?.tag != "InjuredSoldier" && GameManager.Instance.SoldierCounter >= 3)
            {
                TooManySoldierScreen.SetActive(false);
            }
            if (HitCollider?.tag == "Tree")
            {
                EndGame = true;
                HeliAnim.SetBool("Explosion", true);
                GameOver.SetActive(true);
            }
            if (GameManager.Instance.RescuedCounter == SM.TotalSoldiers && SM.Continued == false)
            {
                //Debug.Log("Game won");
                GameWon = true;
                Dropoff.Dropoff.Stop();
                VictoryScreen.SetActive(true);               
            }

            if(EndGame || GameWon)
            {
                GameManager.Instance.Audio.Stop();
                HeliSound.Stop();
            }
        }
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Inputs()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        MoveDirection = new Vector2(x, y).normalized;
    }

    void Movement()
    {
        Body.velocity = new Vector2(MoveDirection.x * MovementSpeed, MoveDirection.y * MovementSpeed);
    }

    private void CountSoldiers()
    {
        Soldiers = GameObject.FindGameObjectsWithTag("InjuredSoldier");

    }
}

