using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatTriggerLeft : MonoBehaviour
{
    public GameObject Boat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Boat.GetComponent<BoatMoveLeft>().speed = 8;
        }
    }
}
