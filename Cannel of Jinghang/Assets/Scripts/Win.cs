using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {
        GameObject canvas = GameObject.Find("WinUI");
        canvas.transform.Find("Panel").gameObject.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject canvas = GameObject.Find("WinUI");
        canvas.transform.Find("Panel").gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Rewind();
        GameObject canvas = GameObject.Find("WinUI");
        canvas.transform.Find("Panel").gameObject.SetActive(false);
    }


    private void Rewind()
    {
        GameObject testBoat = GameObject.Find("TestBoat");
        GameObject player = GameObject.Find("Player");
        testBoat.transform.position = new Vector3(testBoat.transform.position.x, 0, 0);
        testBoat.GetComponent<TestBoatController>().speed += 2;
        player.transform.position = new Vector3(player.transform.position.x, 2, 0);
        player.GetComponent<PlayerController>().speed += 2;
    }
    


}
