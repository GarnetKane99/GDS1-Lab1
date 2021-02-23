using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Script responsible for handling the scoring within the scene
    public static GameManager Instance { get; private set; }

    public int SoldierCounter;
    public int RescuedCounter;

    //Activates when the game is created/started
    public void Awake()
    {  
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
