using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D Body;
    [SerializeField]
    private UIManager UI;
    [SerializeField]
    private SpawnManager SM;
    [SerializeField]
    private GameObject GameOver, VictoryScreen;
    [SerializeField]
    private float Radius;

    public bool EndGame, GameReset, GameWon;
    //public bool GameWon;
    //public bool GameReset;
    public float MovementSpeed;
    public Vector2 MoveDirection;
    public LayerMask layerMask;
    public GameObject[] Soldiers;

    void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
        UI = GameObject.FindObjectOfType<UIManager>();
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
                GameOver = UI.GameOverScreen;
            }
            if (GameOver)
            {
                GameOver.SetActive(false);
            }
            if(!VictoryScreen)
            {
                VictoryScreen = UI.VictoryScreen;
            }
            if(VictoryScreen)
            {
                VictoryScreen.SetActive(false);
            }

            if (HitCollider != null && HitCollider?.tag == "Hospital")
            {
                GameManager.Instance.RescuedCounter += GameManager.Instance.SoldierCounter;
                GameManager.Instance.SoldierCounter = 0;
            }
            if (HitCollider?.tag == "InjuredSoldier" && GameManager.Instance.SoldierCounter < 3)
            {
                Destroy(HitCollider.gameObject);
                GameManager.Instance.SoldierCounter++;
            }
            if (HitCollider?.tag == "Tree")
            {
                EndGame = true;
                GameOver.SetActive(true);
            }
            if (GameManager.Instance.RescuedCounter == SM.TotalSoldiers && SM.Continued == false)
            {
                //Debug.Log("Game won");
                GameWon = true;
                VictoryScreen.SetActive(true);
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

