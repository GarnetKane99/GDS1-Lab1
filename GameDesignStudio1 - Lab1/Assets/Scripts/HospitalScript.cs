using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalScript : MonoBehaviour
{
    public bool AtHospital;
    public int PatientOnHeli;
    GameManager Manager;
    //PlayerManager Player;

    // Start is called before the first frame update
    void Start()
    {
        AtHospital = false;
        PatientOnHeli = 0;
        Manager = FindObjectOfType<GameManager>();
        //Player = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Manager.SoldierCounter > 0 && AtHospital && PatientOnHeli != 0)
        {
            Manager.RescuedCounter += PatientOnHeli;
            PatientOnHeli = 0;
            AtHospital = false;
            //Manager.SoldierCounter = 0;
        }
        if (PatientOnHeli == 0)
            Manager.SoldierCounter = 0;
    }
}
