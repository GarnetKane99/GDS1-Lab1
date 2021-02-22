using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerManager MovementInput;
    SpriteRenderer SpriteRender;

    void Start()
    {
        MovementInput = GetComponent<PlayerManager>();
        SpriteRender = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(MovementInput != null)
        {
            Vector3 CurrentMoveVector = MovementInput.MovementVector;
            if(CurrentMoveVector.x > 0)
            {
                SpriteRender.flipX = false;
            }
            if(CurrentMoveVector.x < 0)
            {
                SpriteRender.flipX = true;
            }
        }
    }
}
