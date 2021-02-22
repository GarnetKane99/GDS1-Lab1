using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D Body;
    
    public Vector2 MoveDirection;
    public float MovementSpeed;
    public GameManager Manager;
    public SoldierScript Soldier;
    public GameObject[] Soldiers;

    void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
        Manager = FindObjectOfType<GameManager>();
        Soldier = FindObjectOfType<SoldierScript>();
        Soldiers = GameObject.FindGameObjectsWithTag("InjuredSoldier");
    }

    void Update()
    {
        Inputs();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "InjuredSoldier" && Soldier != null)
        {
            Debug.Log("Collision with soldier");
            for (int i = 0; i < Soldiers.Length; i++)
            {
                if(collision.tag == "InjuredSoldier" == Soldiers[i])
                //if (Soldier.Soldiers[i] == Soldiers[i])
                {
                    Soldiers[i].GetComponent<SoldierDestroy>().IsRescued = true;
                }
                else
                {
                    Debug.Log("Didn't hit soldier");
                }
            }
        }    
        else
        {
            Debug.Log("Collision detected");
        }
    }
}
