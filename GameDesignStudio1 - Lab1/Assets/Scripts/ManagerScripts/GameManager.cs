using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Script responsible for handling the scoring within the scene
    public static GameManager Instance { get; private set; }

    public int SoldierCounter;
    public int RescuedCounter;

    [SerializeField]
    public GameObject Player, Hospital1, Hospital2, SoldierParent, TreeParent, Canvas, GameOver;

    //Activates when the game is created/started
    public void Awake()
    {
        GameObject Helicopter = Instantiate(Player) as GameObject;
        GameObject SoldierOnScreen = Instantiate(SoldierParent) as GameObject;
        GameObject TreeOnScreen = Instantiate(TreeParent) as GameObject;
        GameObject HospitalA = Instantiate(Hospital1) as GameObject;
        GameObject HospitalB = Instantiate(Hospital2) as GameObject;
        GameObject CanvasOnScreen = Instantiate(Canvas) as GameObject;
        GameObject GameOverScreen = Instantiate(GameOver) as GameObject;

        HospitalA.transform.position = new Vector2(-8, 2);
        HospitalB.transform.position = new Vector2(-8, -2);

        //Helicopter.transform.position = new Vector2(Helicopter.transform.position.x, Helicopter.transform.position.y);

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
