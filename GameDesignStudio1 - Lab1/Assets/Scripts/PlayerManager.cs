using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    CharacterController Controller;
    public Vector3 MovementVector;
    public GameManager MovementInfo;

    void Start()
    {
        //Character Controller that is attached to the character prefab
        Controller = GetComponent<CharacterController>();
        //Finds object in the scene that contains the speed variable
        MovementInfo = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        //Normalize movement vector so helicopter doesn't go insane on diagonals
        MovementVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized;
        //Check if movement is happening
        if (MovementVector.magnitude > 0.05)
        {
            //Finds the GameManager gameobject to find appropriate speed
            if (MovementInfo != null)
            {
                Controller.Move(MovementVector * Time.deltaTime * MovementInfo.MoveSpeed);
            }
            //If not found (should never be the case) uses the normal movementvector and time as movement
            else
            {
                Controller.Move(MovementVector * Time.deltaTime);
            }
        }
    }
}
