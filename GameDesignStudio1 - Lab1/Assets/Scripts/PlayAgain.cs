using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    [SerializeField]
    private SpawnManager SM;

    public void Restart()
    {

        SM = GameManager.Instance.GetComponent<SpawnManager>();
        if(SM)
        {
            SM.BeginRestart();
        }
    }

    public void Continue()
    {
        SM = GameManager.Instance.GetComponent<SpawnManager>();
        if(SM)
        {
            SM.Continue();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
