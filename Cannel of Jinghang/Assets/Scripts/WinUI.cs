using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinUI : MonoBehaviour
{
    // Start is called before the first frame update

    public static int collectionCount;//已收集的收集品数目
    public Animator pa;

    public GameObject FinalAnim;
    public GameObject Player;
    public GameObject winUI;
    public GameObject StarOneFailed;
    public GameObject StarTwoFailed;
    public GameObject StarThreeFailed;
    public GameObject StarOne;
    public GameObject StarTwo;
    public GameObject StarThree;
    public GameObject InGameUI;

    public Text FinalScore;


    void Start()
    {
        collectionCount = 0;//已收集的收集品数目初始化为0
        collectionCount = GameObject.Find("Forever").GetComponent<Forever>().collectNum;
        //Debug.Log(collectionCount);
        //GameObject canvas = GameObject.Find("WinUI");
        //canvas.transform.Find("Panel").gameObject.SetActive(false);
        //canvas.transform.Find("StarOneFailed").gameObject.SetActive(false);
        //canvas.transform.Find("StarTwoFailed").gameObject.SetActive(false);
        //canvas.transform.Find("StarThreeFailed").gameObject.SetActive(false);
        //canvas.transform.Find("StarOne").gameObject.SetActive(false);
        //canvas.transform.Find("StarTwo").gameObject.SetActive(false);
        //canvas.transform.Find("StarThree").gameObject.SetActive(false);


    }

    private void OnTriggerEnter(Collider other)
    {
        InGameUI.SetActive(false);
        Invoke("ActivateUI", 2f);
        Player.SetActive(false);
        FinalAnim.SetActive(true);
        pa.SetBool("Win", true);
        
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    //Rewind();
    //    GameObject canvas = GameObject.Find("WinUI");
    //    canvas.transform.Find("Panel").gameObject.SetActive(false);
    //}


    /*private void Rewind()
    {
        GameObject testBoat = GameObject.Find("TestBoat");
        GameObject player = GameObject.Find("JunkoChan");
        testBoat.transform.position = new Vector3(testBoat.transform.position.x, 0, 0);
        testBoat.GetComponent<TestBoatController>().speed += 2;
        player.transform.position = new Vector3(player.transform.position.x, 2, 0);
        player.GetComponent<PlayerController>().speed += 2;
    }*/

    private void ActivateUI()
    {
        //Debug.Log(collectionCount);
        winUI.SetActive(true);
        StarOne.SetActive(false);
        StarTwo.SetActive(false);
        StarThree.SetActive(false);
        StarOneFailed.SetActive(false);
        StarTwoFailed.SetActive(false);
        StarThreeFailed.SetActive(false);
        if (collectionCount == 0)
        {
            StarOneFailed.SetActive(true);
            StarTwoFailed.SetActive(true);
            StarThreeFailed.SetActive(true);

        }
        if (collectionCount == 1)
        {
            StarOne.SetActive(true);
            StarTwoFailed.SetActive(true);
            StarThreeFailed.SetActive(true);
            
        }
        if (collectionCount == 2)
        {
            StarOne.SetActive(true);
            StarTwo.SetActive(true);
            StarThreeFailed.SetActive(true);
        }
        if (collectionCount == 3)
        {
            StarOne.SetActive(true);
            StarTwo.SetActive(true);
            StarThree.SetActive(true);
        }
        FinalScore.text = "得分:" + UIManager.Instance.score;
    }

}
