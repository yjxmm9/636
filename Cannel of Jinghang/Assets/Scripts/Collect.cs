using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TestBoat" || other.tag == "Player")
        {
            Destroy(this.gameObject);

        }
    }

}
