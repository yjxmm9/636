using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatTriggerRank2 : MonoBehaviour
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
