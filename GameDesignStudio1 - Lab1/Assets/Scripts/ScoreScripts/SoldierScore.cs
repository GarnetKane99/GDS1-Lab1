using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierScore : MonoBehaviour
{
    Text SoldiersInHeli;

    // Start is called before the first frame update
    void Start()
    {
        SoldiersInHeli = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        SoldiersInHeli.text = "Soldiers in Helicopter: " + GameManager.Instance.SoldierCounter;
    }
}
