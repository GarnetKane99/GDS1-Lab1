using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSound : MonoBehaviour
{
    public AudioSource Pickup;
    // Start is called before the first frame update
    void Start()
    {
        Pickup = GetComponent<AudioSource>();
    }
}
