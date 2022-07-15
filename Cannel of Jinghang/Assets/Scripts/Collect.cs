using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TestBoat" || other.tag == "Player")
        {
            WinUI.collectionCount += 1;
            Destroy(this.gameObject);//在收集到之后摧毁该物体
        }
    }

}
