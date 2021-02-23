using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D Body;
    public GameManager Manager;

    //creates an array of soldiers in the scene that can be accessed when picking them up
    public GameObject[] Soldiers;

    //public - needs to be accessed in the animator script
    public float MovementSpeed;
    public Vector2 MoveDirection;

    void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
        Manager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        Inputs();
        CountSoldiers();
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

        if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Game will reset");
        }
    }

    void Movement()
    {
        Body.velocity = new Vector2(MoveDirection.x * MovementSpeed, MoveDirection.y * MovementSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for(int i = 0; i < Soldiers.Length; i++)
        {
            if (Manager.SoldierCounter < 3)
            {
                if (collision.tag == "InjuredSoldier" && Soldiers[i] == collision.gameObject)
                {
                    Soldiers[i].GetComponent<SoldierDestroy>().IsRescued = true;
                    Debug.Log("Soldier Rescued");
                }
            }
            else
            {
                Debug.Log("Carrying too many soldiers");
            }
        }
    }

    private void CountSoldiers()
    {
        Soldiers = GameObject.FindGameObjectsWithTag("InjuredSoldier");
    }
}

