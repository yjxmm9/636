using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraMove : MonoBehaviour
{
    public GameObject TestBoat;

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = new Vector3(TestBoat.transform.position.x, 0, TestBoat.transform.position.z);
    }
}
