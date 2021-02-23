using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D Body;

    public GameObject Hospitals;
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
        Hospitals = GameObject.FindGameObjectWithTag("Hospital");

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
            if (Manager.SoldierCounter < 3 && collision.tag == "InjuredSoldier")
            {
                if (Soldiers[i] == collision.gameObject)
                {
                    Soldiers[i].GetComponent<SoldierDestroy>().IsRescued = true;
                }

            }
            
            else if (Manager.SoldierCounter >= 3 && collision.tag == "InjuredSoldier")
            {
                Debug.Log("Carrying too many soldiers");
            }

            else if (collision.tag == "Hospital" && Manager.SoldierCounter <= 3)
            {
                //AtHospital = true;
                Hospitals.GetComponent<HospitalScript>().AtHospital = true;
            }

            else if (collision.tag == "Tree")
            {
                Debug.Log("Game ended");
            }

        }
    }

    private void CountSoldiers()
    {
        Soldiers = GameObject.FindGameObjectsWithTag("InjuredSoldier");
    }
}

