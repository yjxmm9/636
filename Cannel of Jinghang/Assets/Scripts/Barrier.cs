using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + "��������");
        if (other.name == "TestBoat"|| other.name == "Player")
        {
            Time.timeScale = 0;
        }


    }
}
