using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatTrigger : MonoBehaviour
{
    public GameObject Boat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Boat.GetComponent<BoatMove>().speed = 8;
        }
    }
}
