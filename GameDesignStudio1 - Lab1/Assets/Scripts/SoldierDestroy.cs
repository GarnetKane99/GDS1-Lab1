using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDestroy : MonoBehaviour
{
    public bool IsRescued;

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
            Debug.Log("Rescued this soldier");
            Destroy(gameObject);
        }
    }
}
