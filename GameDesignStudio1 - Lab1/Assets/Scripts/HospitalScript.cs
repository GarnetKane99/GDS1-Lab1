using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalScript : MonoBehaviour
{
    public bool AtHospital;
    GameManager Manager;

    // Start is called before the first frame update
    void Start()
    {
        AtHospital = false;
        Manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.SoldierCounter > 0 && AtHospital)
        {
            Manager.RescuedCounter += Manager.SoldierCounter;
            //Manager.SoldierCounter = 0;
            AtHospital = false;
            StartCoroutine(RemoveSoldierCounter());
        }
    }

    IEnumerator RemoveSoldierCounter()
    {
        yield return new WaitForSeconds(1.0f);
        ResetCounter();
    }

    private void ResetCounter()
    {
        Manager.SoldierCounter = 0;
    }
}
