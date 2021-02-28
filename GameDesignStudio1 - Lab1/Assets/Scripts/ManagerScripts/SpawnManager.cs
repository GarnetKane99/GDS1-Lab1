using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    //Tree things
    [Header("Trees")]
    public int TotalTrees, NewTreesSpawned;
    [SerializeField]
    private int TreesSpawned;
    [SerializeField]
    private float TreeWidth;
    [SerializeField]
    private float TreeHeight;
    [SerializeField]
    private GameObject Tree;
    [SerializeField]
    private GameObject TreeParent;
    [SerializeField]
    private Vector2 TreeBounds;

    //Soldier things

    [Header("Soldier")]
    public int TotalSoldiers, NewSoldiersSpawned;
    [SerializeField]
    private int SoldiersSpawned;
    [SerializeField]
    private float SoldierWidth;
    [SerializeField]
    private float SoldierHeight;
    [SerializeField]
    private GameObject Soldier;
    [SerializeField]
    private GameObject SoldierParent;
    [SerializeField]
    private Vector2 SoldierBounds;

    //PlayerManager
    [SerializeField]
    PlayerManager PM;
    [SerializeField]
    private int SoldierRandomiser;

    public bool Continued;

    // Start is called before the first frame update
    void Start()
    {
        TreeBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        TreeWidth = Tree.transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        TreeHeight = Tree.transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        SoldierBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        SoldierWidth = Soldier.transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        SoldierHeight = Soldier.transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        NewTreesSpawned = 0;
        NewSoldiersSpawned = 0;

        StartCoroutine(TreeTimer());
        StartCoroutine(SoldierTimer());

        Continued = false;
    }

    // Update is called once per frame
    void Update()
    {
        SoldierParent = GameObject.FindGameObjectWithTag("SoldierParent");
        TreeParent = GameObject.FindGameObjectWithTag("TreeParent");

        PM = FindObjectOfType<PlayerManager>();

        if (PM != null && !PM.EndGame && !PM.GameWon)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                BeginRestart();
            }
        }

        NewSpawn();
    }

    public void BeginRestart()
    {
        TotalSoldiers = TotalSoldiers - NewSoldiersSpawned;
        TotalTrees = TotalTrees - NewTreesSpawned;
        NewSoldiersSpawned = 0;
        NewTreesSpawned = 0;
        SoldiersSpawned = 0;
        TreesSpawned = 0;
        Continued = false;
        GameManager.Instance.SoldierCounter = 0;
        GameManager.Instance.RescuedCounter = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Continue()
    {
        Continued = true;
        PM.GameWon = false;
    }

    IEnumerator TreeTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            if (TreesSpawned < TotalTrees && Continued == false)
            {
                SpawnTree();
            }
            if (TreesSpawned < TotalTrees && Continued == true)
            {
                SpawnTree();
            }
        }
    }

    IEnumerator SoldierTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            if (SoldiersSpawned < TotalSoldiers && Continued == false)
            {
                SpawnSoldier();
            }
            if (SoldiersSpawned < TotalSoldiers && Continued == true)
            {
                SpawnSoldier();
            }
        }
    }

    private void SpawnTree()
    {
        if(TreeParent)
        {
            GameObject TreeObject = Instantiate(Tree, TreeParent.transform) as GameObject;
            TreesSpawned++;
            TreeObject.transform.position = new Vector2(Random.Range(0, TreeBounds.x - TreeWidth), Random.Range(-TreeBounds.y + TreeHeight, TreeBounds.y - TreeHeight));
        }
    }

    private void SpawnSoldier()
    { 
        if (SoldierParent)
        {
            GameObject SoldierObject = Instantiate(Soldier, SoldierParent.transform) as GameObject;
            SoldiersSpawned++;
            SoldierObject.transform.position = new Vector2(Random.Range(0, SoldierBounds.x - SoldierWidth), Random.Range(-SoldierBounds.y + SoldierHeight, SoldierBounds.y - SoldierHeight));
        }
    }

    private void NewSpawn()
    {
        if(GameManager.Instance.RescuedCounter == TotalSoldiers && Continued == true)
        {
            SoldierRandomiser = Random.Range(1, 10);
            Debug.Log("Soldier Randomiser: " + SoldierRandomiser);
            NewSoldiersSpawned += SoldierRandomiser;
            TotalSoldiers += SoldierRandomiser;

            if(SoldierRandomiser <= 3)
            {
                PM.MovementSpeed = PM.MovementSpeed + 1;
                NewTreesSpawned = NewTreesSpawned + 1;
                TotalTrees = TotalTrees + 1;
            }
            else if (SoldierRandomiser >3 && SoldierRandomiser <= 7)
            {
                NewTreesSpawned = NewTreesSpawned + 1;
                TotalTrees = TotalTrees + 1;
            }
            else if (SoldierRandomiser > 7)
            {
                PM.MovementSpeed = PM.MovementSpeed + 1;
            }
        }     
    }
}
