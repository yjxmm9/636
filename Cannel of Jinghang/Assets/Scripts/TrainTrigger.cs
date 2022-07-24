using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainTrigger : MonoBehaviour
{
    public GameObject Train;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Train.GetComponent<TrainMove>().speed = -16f;
        }
    }

}
