using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BulletPrefab;
    public Transform BulletPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Instantiate(BulletPrefab,BulletPosition);
        }
    }


}
