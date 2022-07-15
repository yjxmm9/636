using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour
{
    // Start is called before the first frame update

    public static int collectionCount;//已收集的收集品数目

    void Start()
    {
        collectionCount = 0;//已收集的收集品数目初始化为0

        GameObject canvas = GameObject.Find("WinUI");
        canvas.transform.Find("Panel").gameObject.SetActive(false);
        canvas.transform.Find("StarOneFailed").gameObject.SetActive(false);
        canvas.transform.Find("StarTwoFailed").gameObject.SetActive(false);
        canvas.transform.Find("StarThreeFailed").gameObject.SetActive(false);
        canvas.transform.Find("StarOne").gameObject.SetActive(false);
        canvas.transform.Find("StarTwo").gameObject.SetActive(false);
        canvas.transform.Find("StarThree").gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject canvas = GameObject.Find("WinUI");
        canvas.transform.Find("Panel").gameObject.SetActive(true);
        if(collectionCount == 0)
        {
            canvas.transform.Find("StarOneFailed").gameObject.SetActive(true);
            canvas.transform.Find("StarTwoFailed").gameObject.SetActive(true);
            canvas.transform.Find("StarThreeFailed").gameObject.SetActive(true);
        }
        if(collectionCount == 1)
        {
            canvas.transform.Find("StarOne").gameObject.SetActive(true);
            canvas.transform.Find("StarTwoFailed").gameObject.SetActive(true);
            canvas.transform.Find("StarThreeFailed").gameObject.SetActive(true);
        }
        if(collectionCount == 2)
        {
            canvas.transform.Find("StarOne").gameObject.SetActive(true);
            canvas.transform.Find("StarTwo").gameObject.SetActive(true);
            canvas.transform.Find("StarThreeFailed").gameObject.SetActive(true);
        }
        if(collectionCount == 3)
        {
            canvas.transform.Find("StarOne").gameObject.SetActive(true);
            canvas.transform.Find("StarTwo").gameObject.SetActive(true);
            canvas.transform.Find("StarThree").gameObject.SetActive(true);
        }
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
        GameObject player = GameObject.Find("JunkoChan");
        testBoat.transform.position = new Vector3(testBoat.transform.position.x, 0, 0);
        testBoat.GetComponent<TestBoatController>().speed += 2;
        player.transform.position = new Vector3(player.transform.position.x, 2, 0);
        player.GetComponent<PlayerController>().speed += 2;
    }
    
    

}
