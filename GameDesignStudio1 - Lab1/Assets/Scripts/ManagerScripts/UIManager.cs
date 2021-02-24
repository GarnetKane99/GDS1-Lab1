using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //public Text PointsText;
    PlayerManager Player;
    public GameObject GameOverScreen;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        Player = FindObjectOfType<PlayerManager>();
        if (Player)
        {
            if (Player.EndGame)
            {
                GameOverScreen.SetActive(true);
            }
            else
            {
                GameOverScreen.SetActive(false);
            }
        }
    }

    public void PlayAgain()
    {
        //Debug.Log("Playing again clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
