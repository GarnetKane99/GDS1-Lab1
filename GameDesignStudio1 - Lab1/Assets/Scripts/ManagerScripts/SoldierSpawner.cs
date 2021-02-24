using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawner : MonoBehaviour
{
    [SerializeField]
    private int TotalSoldiers, SoldiersSpawned;
    [SerializeField]
    private float SoldierWidth, SoldierHeight;
    [SerializeField]
    private GameObject Soldier, SoldierParent;

    PlayerManager PM;

    private Vector2 ScreenBounds;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        SoldierWidth = Soldier.transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        SoldierHeight = Soldier.transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        SoldierParent = GameObject.FindGameObjectWithTag("SoldierParent");
        PM = FindObjectOfType<PlayerManager>();

        if(PM != null && Input.GetKeyDown(KeyCode.R))
        {
            SoldiersSpawned = 0;
        }
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            if (SoldiersSpawned < TotalSoldiers)
            {
                Spawn();
            }
        }
    }

    private void Spawn()
    {
        //GameObject SoldierObject = Instantiate(Soldier, SoldierParent.transform) as GameObject;
        if (SoldierParent)
        {
            GameObject SoldierObject = Instantiate(Soldier, SoldierParent.transform) as GameObject;
            SoldiersSpawned++;
            SoldierObject.transform.position = new Vector2(Random.Range(0, ScreenBounds.x - SoldierWidth), Random.Range(-ScreenBounds.y + SoldierHeight, ScreenBounds.y - SoldierHeight));
        }
        else if (!SoldierParent)
        {
            Debug.Log("No soldier parent found");
        }
    }
}
