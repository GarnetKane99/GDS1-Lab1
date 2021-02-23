using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField]
    private int TotalTrees, TreesSpawned;
    [SerializeField]
    private float TreeWidth, TreeHeight;
    [SerializeField]
    private GameObject Tree;

    private Vector2 ScreenBounds;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        TreeWidth = Tree.transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        TreeHeight = Tree.transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            if (TreesSpawned < TotalTrees)
            {
                Spawn();
            }
        }
    }

    private void Spawn()
    {
        GameObject SoldierObject = Instantiate(Tree) as GameObject;
        TreesSpawned++;

        SoldierObject.transform.position = new Vector2(Random.Range(0, ScreenBounds.x - TreeWidth), Random.Range(-ScreenBounds.y + TreeHeight, ScreenBounds.y - TreeHeight));
    }
}
