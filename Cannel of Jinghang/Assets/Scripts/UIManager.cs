using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public Text ScoreText;
    public int score;
    public GameObject AnswerUI;
    public GameObject TestBoat;
    public GameObject Player;
    public GameObject DieUI;
    public GameObject answerUI;
    public GameObject ButtonAnswer;
    public GameObject Forever;
    public GameObject PauseUI;
    public GameObject CountUI;
    public GameObject Collect1;
    public GameObject Collect2;
    public GameObject Collect3;
    public GameObject noCollect1;
    public GameObject noCollect2;
    public GameObject noCollect3;
    public GameObject CollectionUI;
    public Image Pauseimage;
    public Sprite[] pauseSprites;

    static Vector3 newposition;
    private float speed;

    public static UIManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void UpdateUI(int s)//游戏中得分刷新功能
    {
        score += s;
        ScoreText.text = "得分："+score;
    }

    public void Again()//再来一次按钮
    {
        Time.timeScale = 1;
        WinUI.collectionCount = 0;
        if (SceneManager.GetActiveScene().buildIndex==2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
        else if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }
        else if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(4);
        }
        
    }

    public void Menu()//菜单按钮
    {
        Destroy(Forever);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void Answer()//回答问题复活按钮
    {
        AnswerUI.SetActive(true);
    }

    public void Pause()//暂停按钮
    {
        Time.timeScale = 0;
        Pauseimage.sprite = pauseSprites[1];
        PauseUI.SetActive(true); 
        speed = TestBoat.GetComponent<TestBoatController>().speed;//获取现在的船速度
        TestBoat.GetComponent<TestBoatController>().speed = 0;//将船速设为=0，即达到暂停而timescale不为0
        Player.GetComponent<PlayerController>().speed = 0;//将Player速度设为0
    }

    public void Continue()//继续按钮
    {
        PauseUI.SetActive(false);
        Pauseimage.sprite = pauseSprites[0];
        StartCoroutine(CountUI.GetComponent<CountDown>().CountDownIE());
        Player.GetComponent<PlayerController>().boatAudioSource.Play();

    }

    public void Collect()//打开收集界面
    {
        CollectionUI.transform.Find("Panel").gameObject.SetActive(true);
        GameObject.Find("WinUI").gameObject.transform.Find("Panel").gameObject.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (PlayerPrefs.GetInt("haveCollect1_1") == 1)
            {
                Collect1.SetActive(true);
                noCollect1.SetActive(false);
            }
            else
            {
                Collect1.SetActive(false);
                noCollect1.SetActive(true);
            }
            if (PlayerPrefs.GetInt("haveCollect1_2") == 1)
            {
                Collect2.SetActive(true);
                noCollect2.SetActive(false);
            }
            else
            {
                Collect2.SetActive(false);
                noCollect2.SetActive(true);
            }
            if (PlayerPrefs.GetInt("haveCollect1_3") == 1)
            {
                Collect3.SetActive(true);
                noCollect3.SetActive(false);
            }
            else
            {
                Collect3.SetActive(false);
                noCollect3.SetActive(true);
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (PlayerPrefs.GetInt("haveCollect2_1") == 1)
            {
                Collect1.SetActive(true);
                noCollect1.SetActive(false);
            }
            else
            {
                Collect1.SetActive(false);
                noCollect1.SetActive(true);
            }
            if (PlayerPrefs.GetInt("haveCollect2_2") == 1)
            {
                Collect2.SetActive(true);
                noCollect2.SetActive(false);
            }
            else
            {
                Collect2.SetActive(false);
                noCollect2.SetActive(true);
            }
            if (PlayerPrefs.GetInt("haveCollect2_3") == 1)
            {
                Collect3.SetActive(true);
                noCollect3.SetActive(false);
            }
            else
            {
                Collect3.SetActive(false);
                noCollect3.SetActive(true);
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (PlayerPrefs.GetInt("haveCollect3_1") == 1)
            {
                Collect1.SetActive(true);
                noCollect1.SetActive(false);
            }
            else
            {
                Collect1.SetActive(false);
                noCollect1.SetActive(true);
            }
            if (PlayerPrefs.GetInt("haveCollect3_2") == 1)
            {
                Collect2.SetActive(true);
                noCollect2.SetActive(false);
            }
            else
            {
                Collect2.SetActive(false);
                noCollect2.SetActive(true);
            }
            if (PlayerPrefs.GetInt("haveCollect3_3") == 1)
            {
                Collect3.SetActive(true);
                noCollect3.SetActive(false);
            }
            else
            {
                Collect3.SetActive(false);
                noCollect3.SetActive(true);
            }
        }
        
    }

    public void ReturnButton()//收集界面返回结算界面
    {
        GameObject.Find("WinUI").gameObject.transform.Find("Panel").gameObject.SetActive(true);
        GameObject CollectionUI = GameObject.Find("CollectionUI");
        CollectionUI.transform.Find("Panel").gameObject.SetActive(false);
    }

    public void Collect1Return()
    {
        GameObject CollectionUI = GameObject.Find("CollectionUI");
        CollectionUI.transform.Find("Panel").gameObject.SetActive(true);
        GameObject Details = GameObject.Find("Details");
        Details.transform.Find("Details1").gameObject.SetActive(false);
    }

    public void Collect2Return()
    {
        GameObject CollectionUI = GameObject.Find("CollectionUI");
        CollectionUI.transform.Find("Panel").gameObject.SetActive(true);
        GameObject Details = GameObject.Find("Details");
        Details.transform.Find("Details2").gameObject.SetActive(false);
    }

    public void Collect3Return()
    {
        GameObject CollectionUI = GameObject.Find("CollectionUI");
        CollectionUI.transform.Find("Panel").gameObject.SetActive(true);
        GameObject Details = GameObject.Find("Details");
        Details.transform.Find("Details3").gameObject.SetActive(false);
    }

    public void DetailsOfOne()
    {
        GameObject CollectionUI = GameObject.Find("CollectionUI");
        CollectionUI.transform.Find("Panel").gameObject.SetActive(false);
        GameObject Details = GameObject.Find("Details");
        Details.transform.Find("Details1").gameObject.SetActive(true);
    }

    public void DetailsOfTwo()
    {
        GameObject CollectionUI = GameObject.Find("CollectionUI");
        CollectionUI.transform.Find("Panel").gameObject.SetActive(false);
        GameObject Details = GameObject.Find("Details");
        Details.transform.Find("Details2").gameObject.SetActive(true);
    }

    public void DetailsOfThree()
    {
        GameObject CollectionUI = GameObject.Find("CollectionUI");
        CollectionUI.transform.Find("Panel").gameObject.SetActive(false);
        GameObject Details = GameObject.Find("Details");
        Details.transform.Find("Details3").gameObject.SetActive(true);
    }

    public void NextLevel1()
    {
        Destroy(Forever);
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    public void NextLevel2()
    {
        Destroy(Forever);
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

    public void Revive()//复活
    {
        GameObject.Find("Forever").GetComponent<Forever>().newpositionplayer = new Vector3(Player.transform.position.x, 0,Player.transform.position.z) - 20 * Vector3.forward;
        GameObject.Find("Forever").GetComponent<Forever>().newpositionboat = TestBoat.transform.position - 20 * Vector3.forward;
        GameObject.Find("Forever").GetComponent<Forever>().isrevivedplayer = true;
        GameObject.Find("Forever").GetComponent<Forever>().isrevivedboat = true;
        GameObject.Find("Forever").GetComponent<Forever>().isrevivedbutton = true;
        GameObject.Find("Forever").GetComponent<Forever>().lastScore = score;
        GameObject.Find("Forever").GetComponent<Forever>().collectNum = WinUI.collectionCount;
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(4);
        }
    }



    
}
