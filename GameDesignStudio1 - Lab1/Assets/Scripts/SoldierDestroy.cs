using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDestroy : MonoBehaviour
{
    public bool IsRescued;

    GameManager Manager;

    private void Awake()
    {
        Manager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        IsRescued = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRescued)
        {
            Manager.SoldierCounter++;
            Debug.Log(Manager.SoldierCounter.ToString());
            Destroy(gameObject);
        }        
    }
}
