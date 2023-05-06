using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    //will be removed and replaced in zombie script with ray detection and distance
    //overall set a collison zone for the zombie to follow the player and if the player is not in the zone then the zombie will go back to its start position
    public bool PlayerIn;
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            PlayerIn = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerIn = true;
        }
    }
}
