using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawner : MonoBehaviour
{
    [SerializeField]
    private int TotalSoldiers, Width, Height, SoldiersSpawned;
    [SerializeField]
    private float SoldierWidth, SoldierHeight;
    [SerializeField]
    private GameObject Soldier;
    [SerializeField]
    private Vector2[] SoldierLocations;

    private Vector2 ScreenBounds;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        SoldierWidth = Soldier.transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        SoldierHeight = Soldier.transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        SoldierLocations = new Vector2[TotalSoldiers];
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (SoldiersSpawned < TotalSoldiers)
            {
                Spawn();
            }
        }
    }

    private void Spawn()
    {
        for (int i = 0; i < SoldierLocations.Length; i++)
        {
            GameObject SoldierObject = Instantiate(Soldier) as GameObject;
            SoldiersSpawned++;
            
            SoldierObject.transform.position = new Vector2(Random.Range(0, ScreenBounds.x - SoldierWidth), Random.Range(-ScreenBounds.y + SoldierHeight, ScreenBounds.y - SoldierHeight));
            SoldierLocations[i].x = SoldierObject.transform.position.x;            
        }
    }

}
