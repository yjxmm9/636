using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcboattrigger1 : MonoBehaviour
{
    public GameObject Boat;
    public GameObject Boat1;
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
            Boat.GetComponent<npcboat>().speed = 0;
            Invoke("SecBoat", 2.5f);
        }
    }

    private void SecBoat()
    {
        Boat1.GetComponent<npcboat>().speed = speed;
    }
}
