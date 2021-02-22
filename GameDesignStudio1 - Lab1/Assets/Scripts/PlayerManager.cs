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

    void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
        Manager = FindObjectOfType<GameManager>();
        Soldier = FindObjectOfType<SoldierScript>();
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
            Soldier.Grounded = false;
            //Manager.SoldierCounter++;
            
        }    
        else
        {
            Debug.Log("Collision detected");
        }
    }
}
