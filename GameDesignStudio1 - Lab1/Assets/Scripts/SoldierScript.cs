using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierScript : MonoBehaviour
{
    public bool Grounded;
    //public SpriteRenderer Soldier;
    public GameObject[] Soldiers;

    // Start is called before the first frame update
    private void Awake()
    {
        //Soldier = GetComponentInChildren<GameObject>();
        Soldiers = GameObject.FindGameObjectsWithTag("InjuredSoldier");
    }

    void Start()
    {
        Grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        Pickup();
    }

    public void Pickup()
    {
        if(Grounded == false)
        {
            //Debug.Log("Picked up by helicopter");
            Destroy(gameObject);
            Grounded = true;
        }
    }
}
