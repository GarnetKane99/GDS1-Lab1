using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropoffSound : MonoBehaviour
{
    public AudioSource Dropoff;
    // Start is called before the first frame update
    void Start()
    {
        Dropoff = GetComponent<AudioSource>();
    }
}
