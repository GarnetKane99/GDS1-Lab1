using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D Body;
    public GameManager Manager;

    public LayerMask layerMask;
    public float Radius;
    public bool EndGame;

    public bool GameReset;

    public GameObject GameOver;


    //creates an array of soldiers in the scene that can be accessed when picking them up
    public GameObject[] Soldiers;

    //public - needs to be accessed in the animator script
    public float MovementSpeed;

    public Vector2 MoveDirection;

    void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
        Manager = FindObjectOfType<GameManager>();

        EndGame = false;
        GameReset = false;
    }

    void Update()
    {
        if (!EndGame)
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

            if (HitCollider != null && HitCollider?.tag == "Hospital")
            {
                GameManager.Instance.RescuedCounter += GameManager.Instance.SoldierCounter;
                GameManager.Instance.SoldierCounter = 0;
                //Debug.Log("At hospital");
            }
            if (HitCollider?.tag == "InjuredSoldier" && GameManager.Instance.SoldierCounter < 3)
            {
                //HitCollider.GetComponent<SoldierDestroy>().IsRescued = true;
                Destroy(HitCollider.gameObject);
                GameManager.Instance.SoldierCounter++;
            }
            if (HitCollider?.tag == "Tree")
            {
                EndGame = true;
                GameOver.SetActive(true);
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

