using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
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
