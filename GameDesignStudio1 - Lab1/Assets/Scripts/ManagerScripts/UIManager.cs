using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject UI, VictoryScreen, GameOverScreen;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject UserInterface = Instantiate(UI) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(!VictoryScreen)
        {
            VictoryScreen = GameObject.FindGameObjectWithTag("VictoryScreen");
            VictoryScreen.SetActive(false);
        }
        if(!GameOverScreen)
        {
            GameOverScreen = GameObject.FindGameObjectWithTag("GameOverScreen");
            GameOverScreen.SetActive(false);
        }
    }
}
