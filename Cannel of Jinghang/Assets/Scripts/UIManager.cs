using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public Text ScoreText;
    public int score=0;
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


    static Vector3 newposition;
    private float speed;

    //public int revivetime=0;

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
        DontDestroyOnLoad(Forever);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI(int s)
    {
        score += s;
        ScoreText.text = "得分："+score;
    }

    public void Again()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);//TODO
    }

    public void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void Answer()
    {
        AnswerUI.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PauseUI.SetActive(true); 
        speed = TestBoat.GetComponent<TestBoatController>().speed;//获取现在的船速度
        TestBoat.GetComponent<TestBoatController>().speed = 0;//将船速设为=0，即达到暂停而timescale不为0
        Player.GetComponent<PlayerController>().speed = 0;//将Player速度设为0
    }

    public void Continue()
    {
        PauseUI.SetActive(false);
        StartCoroutine(CountUI.GetComponent<CountDown>().CountDownIE());
        Player.GetComponent<PlayerController>().boatAudioSource.Play();

    }

    public void Collect()
    {
        CollectionUI.SetActive(true);
        if (PlayerPrefs.GetInt("haveCollect1_1")==1)
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

    public void ReturnButton()
    {
        GameObject.Find("WinUI").gameObject.transform.Find("Panel").gameObject.SetActive(true);
        GameObject CollectionUI = GameObject.Find("CollectionUI");
        CollectionUI.transform.Find("Panel").gameObject.SetActive(false);
    }


    public void DetailsOfOne()
    {

    }

    public void DetailsOfTwo()
    {

    }

    public void DetailsOfThree()
    {

    }


    public void Revive()
    {
        //GameObject testBoat = GameObject.Find("TestBoat");
        //GameObject player = GameObject.Find("JunkoChan");

        //TestBoat.transform.position = new Vector3(testBoat.transform.position.x, 0, testBoat.transform.position.z-20);
        //Player.transform.position = new Vector3(player.transform.position.x, 2, player.transform.position.z-20);

        GameObject.Find("Forever").GetComponent<Forever>().newpositionplayer = new Vector3(Player.transform.position.x, 0,Player.transform.position.z) - 20 * Vector3.forward;
        GameObject.Find("Forever").GetComponent<Forever>().newpositionboat = TestBoat.transform.position - 20 * Vector3.forward;
        GameObject.Find("Forever").GetComponent<Forever>().isrevivedplayer = true;
        GameObject.Find("Forever").GetComponent<Forever>().isrevivedboat = true;
        GameObject.Find("Forever").GetComponent<Forever>().isrevivedbutton = true;
        GameObject.Find("Forever").GetComponent<Forever>().lastScore = score;
        GameObject.Find("Forever").GetComponent<Forever>().collectNum = WinUI.collectionCount;
        //Debug.Log(GameObject.Find("Forever").GetComponent<Forever>().collectNum);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        //Instantiate(Player, newposition, Quaternion.identity);
        //Instantiate(TestBoat, newposition, Quaternion.identity);
        //Destroy(Player);
        //Destroy(TestBoat);
        //Player.transform.position = newposition;
        //TestBoat.transform.position = newposition;

        //Time.timeScale = 1;
        //AnswerUI.SetActive(false);
        //DieUI.SetActive(false);
        //Destroy(ButtonAnswer);
        
    }



    //public void AfterRevive()
    //{
    //    Time.timeScale = 0;
    //    Player.transform.position = newposition;
    //    TestBoat.transform.position = newposition;
    //    AnswerUI.SetActive(false);
    //    DieUI.SetActive(false);
    //    Destroy(ButtonAnswer);
    //    Time.timeScale = 1;
        
    //}

    //private void CheckForward(GameObject go)
    //{//Judge whether Junkochan is on the ground or not
    //    Ray ray = new Ray(go.transform.position + Vector3.up , Vector3.forward * 1f);
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray,out hit))
    //    {
    //        Destroy(hit.collider.gameObject);
    //    }
    //}
}
