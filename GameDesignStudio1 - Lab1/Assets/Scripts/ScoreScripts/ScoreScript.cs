using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    Text RescuedHelicopter;

    // Start is called before the first frame update
    void Start()
    {
        RescuedHelicopter = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        RescuedHelicopter.text = "Rescued Soldiers: " + GameManager.Instance.RescuedCounter;
    }
}
