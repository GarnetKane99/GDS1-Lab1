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
        SpriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(MovementInput != null)
        {
            Vector2 CurrentMoveVector = MovementInput.MoveDirection;
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
