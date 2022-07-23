using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatTrigger : MonoBehaviour
{


    public GameObject Boat;
    public int speed;
    public GameObject CountDownUI;


    private void OnTriggerEnter(Collider other)
    {
        if (CountDownUI.GetComponent<CountDown>().iscounting)
        {
            return;
        }
        if (other.tag == "Player")
        {
            Boat.GetComponent<Boat>().speed = speed;
        }
    }

}
