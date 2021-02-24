using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    //Tree things
    [SerializeField]
    [Header("Trees")]
    private int TotalTrees;
    public int TreesSpawned;
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
    [SerializeField]
    [Header("Soldier")]
    private int TotalSoldiers;
    public int SoldiersSpawned;
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

    // Start is called before the first frame update
    void Start()
    {
        TreeBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        TreeWidth = Tree.transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        TreeHeight = Tree.transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        SoldierBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        SoldierWidth = Soldier.transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        SoldierHeight = Soldier.transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        StartCoroutine(TreeTimer());
        StartCoroutine(SoldierTimer());
    }

    // Update is called once per frame
    void Update()
    {
        SoldierParent = GameObject.FindGameObjectWithTag("SoldierParent");
        TreeParent = GameObject.FindGameObjectWithTag("TreeParent");

        PM = FindObjectOfType<PlayerManager>();

        if (PM != null && !PM.EndGame)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                BeginRestart();
            }
        }
    }

    public void BeginRestart()
    {
        SoldiersSpawned = 0;
        TreesSpawned = 0;
        GameManager.Instance.SoldierCounter = 0;
        GameManager.Instance.RescuedCounter = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator TreeTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            if (TreesSpawned < TotalTrees)
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
            if (SoldiersSpawned < TotalSoldiers)
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
}
