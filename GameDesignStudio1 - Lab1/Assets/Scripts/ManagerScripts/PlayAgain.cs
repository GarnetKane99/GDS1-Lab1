using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    [SerializeField]
    private SpawnManager SM;
    private PlayerManager PM;

    public void Restart()
    {

        SM = GameManager.Instance.GetComponent<SpawnManager>();
        if(SM)
        {
            SM.BeginRestart();
            GameManager.Instance.Audio.Play();
        }
    }

    public void Continue()
    {
        SM = GameManager.Instance.GetComponent<SpawnManager>();
        PM = FindObjectOfType<PlayerManager>();
        if(SM)
        {
            SM.Continue();
            GameManager.Instance.Audio.Play();
            PM.HeliSound.Play();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
