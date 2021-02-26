using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierFullScript : MonoBehaviour
{
    Text TooManySoldiers;

    // Start is called before the first frame update
    void Start()
    {
        TooManySoldiers = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        TooManySoldiers.text = "Carrying too many soldiers!";
    }
}
