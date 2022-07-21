using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinUI : MonoBehaviour
{
    // Start is called before the first frame update

    public static int collectionCount=0;//已收集的收集品数目
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


    private void OnTriggerEnter(Collider other)
    {
        InGameUI.SetActive(false);
        Invoke("ActivateUI", 2f);
        Player.SetActive(false);
        FinalAnim.SetActive(true);
        pa.SetBool("Win", true);
        GameObject.Find("Forever").GetComponent<Forever>().isrevivedbutton = false;
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            PlayerPrefs.SetInt("r1success", 1);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            PlayerPrefs.SetInt("r2success", 1);
        }
    }

    private void ActivateUI()
    {
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
