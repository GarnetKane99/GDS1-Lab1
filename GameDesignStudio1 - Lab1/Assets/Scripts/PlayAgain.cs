using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgain : MonoBehaviour
{
    public void Restart()
    {
        SpawnManager SM;
        SM = GameManager.Instance.GetComponent<SpawnManager>();
        if(SM)
        {
            SM.BeginRestart();
        }
    }
}
