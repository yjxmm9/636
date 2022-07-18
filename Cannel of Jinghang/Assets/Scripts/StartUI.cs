using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{

    public GameObject SettingUI;
    public GameObject PlayUI;
    public GameObject MainMenu;
    public GameObject CollectionUI;
    public GameObject Collect1_1;
    public GameObject Collect1_2;
    public GameObject Collect1_3;
    public GameObject Collect2_1;
    public GameObject Collect2_2;
    public GameObject Collect2_3;
    public GameObject Collect3_1;
    public GameObject Collect3_2;
    public GameObject Collect3_3;
    public GameObject noCollect1_1;
    public GameObject noCollect1_2;
    public GameObject noCollect1_3;
    public GameObject noCollect2_1;
    public GameObject noCollect2_2;
    public GameObject noCollect2_3;
    public GameObject noCollect3_1;
    public GameObject noCollect3_2;
    public GameObject noCollect3_3;

    // Start is called before the first frame update
    void Start()
    {
        
        SettingUI.SetActive(false);//将其初始化设置为不显示
        PlayUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Setting()
    {
        
        SettingUI.SetActive(true);//将其初始化设置为不显示
    }

    public void Back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void PlayCheck()
    {
        PlayUI.SetActive(true);
    }

    public void Collect()
    {
        CollectionUI.transform.Find("Panel").gameObject.SetActive(true);//打开收集品UI的第一页
        MainMenu.SetActive(false);//关闭MainMene
        if (PlayerPrefs.GetInt("haveCollect1_1",0) == 1)
        {
            Collect1_1.SetActive(true);
            noCollect1_1.SetActive(false);
        }
        else
        {
            Collect1_1.SetActive(false);
            noCollect1_1.SetActive(true);
        }
        if (PlayerPrefs.GetInt("haveCollect1_2",0) == 1)
        {
            Collect1_2.SetActive(true);
            noCollect1_2.SetActive(false);
        }
        else
        {
            Collect1_2.SetActive(false);
            noCollect1_2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("haveCollect1_3",0) == 1)
        {
            Collect1_3.SetActive(true);
            noCollect1_3.SetActive(false);
        }
        else
        {
            Collect1_3.SetActive(false);
            noCollect1_3.SetActive(true);
        }
    }

    public void NextOnOne()
    {
        GameObject CollectionOneUI = GameObject.Find("CollectionOneUI");
        CollectionOneUI.transform.Find("Panel").gameObject.SetActive(false);//关闭收集品UI的第一页
        GameObject CollectionTwoUI = GameObject.Find("CollectionTwoUI");
        CollectionTwoUI.transform.Find("Panel").gameObject.SetActive(true);//打开收集品UI的第二页
        if (PlayerPrefs.GetInt("haveCollect2_1",0) == 1)
        {
            Collect2_1.SetActive(true);
            noCollect2_1.SetActive(false);
        }
        else
        {
            Collect2_1.SetActive(false);
            noCollect2_1.SetActive(true);
        }
        if (PlayerPrefs.GetInt("haveCollect2_2",0) == 1)
        {
            Collect2_2.SetActive(true);
            noCollect2_2.SetActive(false);
        }
        else
        {
            Collect2_2.SetActive(false);
            noCollect2_2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("haveCollect2_3",0) == 1)
        {
            Collect2_3.SetActive(true);
            noCollect2_3.SetActive(false);
        }
        else
        {
            Collect2_3.SetActive(false);
            noCollect2_3.SetActive(true);
        }
    }

    public void NextOnTwo()
    {
        GameObject CollectionTwoUI = GameObject.Find("CollectionTwoUI");
        CollectionTwoUI.transform.Find("Panel").gameObject.SetActive(false);//关闭收集品UI的第二页
        GameObject CollectionThreeUI = GameObject.Find("CollectionThreeUI");
        CollectionThreeUI.transform.Find("Panel").gameObject.SetActive(true);//打开收集品UI的第三页
        if (PlayerPrefs.GetInt("haveCollect3_1",0) == 1)
        {
            Collect3_1.SetActive(true);
            noCollect3_1.SetActive(false);
        }
        else
        {
            Collect3_1.SetActive(false);
            noCollect3_1.SetActive(true);
        }
        if (PlayerPrefs.GetInt("haveCollect3_2",0) == 1)
        {
            Collect3_2.SetActive(true);
            noCollect3_2.SetActive(false);
        }
        else
        {
            Collect3_2.SetActive(false);
            noCollect3_2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("haveCollect3_3",0) == 1)
        {
            Collect3_3.SetActive(true);
            noCollect3_3.SetActive(false);
        }
        else
        {
            Collect3_3.SetActive(false);
            noCollect3_3.SetActive(true);
        }
    }

    public void ReturnButton()
    {
        GameObject CollectionUI = GameObject.Find("CollectionOneUI");
        CollectionUI.transform.Find("Panel").gameObject.SetActive(false);//关闭收集品UI的第一页
        MainMenu.SetActive(true);//打开MainMene
    }

    public void ReturnOnTwo()
    {
        GameObject CollectionOneUI = GameObject.Find("CollectionOneUI");
        CollectionOneUI.transform.Find("Panel").gameObject.SetActive(true);//打开收集品UI的第一页
        GameObject CollectionTwoUI = GameObject.Find("CollectionTwoUI");
        CollectionTwoUI.transform.Find("Panel").gameObject.SetActive(false);//关闭收集品UI的第二页
        if (PlayerPrefs.GetInt("haveCollect1_1",0) == 1)
        {
            Collect1_1.SetActive(true);
            noCollect1_1.SetActive(false);
        }
        else
        {
            Collect1_1.SetActive(false);
            noCollect1_1.SetActive(true);
        }
        if (PlayerPrefs.GetInt("haveCollect1_2",0) == 1)
        {
            Collect1_2.SetActive(true);
            noCollect1_2.SetActive(false);
        }
        else
        {
            Collect1_2.SetActive(false);
            noCollect1_2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("haveCollect1_3",0) == 1)
        {
            Collect1_3.SetActive(true);
            noCollect1_3.SetActive(false);
        }
        else
        {
            Collect1_3.SetActive(false);
            noCollect1_3.SetActive(true);
        }
    }

    public void ReturnOnThree()
    {
        GameObject CollectionTwoUI = GameObject.Find("CollectionTwoUI");
        CollectionTwoUI.transform.Find("Panel").gameObject.SetActive(true);//打开收集品UI的第二页
        GameObject CollectionThreeUI = GameObject.Find("CollectionThreeUI");
        CollectionThreeUI.transform.Find("Panel").gameObject.SetActive(false);//关闭收集品UI的第三页
        if (PlayerPrefs.GetInt("haveCollect2_1",0) == 1)
        {
            Collect2_1.SetActive(true);
            noCollect2_1.SetActive(false);
        }
        else
        {
            Collect2_1.SetActive(false);
            noCollect2_1.SetActive(true);
        }
        if (PlayerPrefs.GetInt("haveCollect2_2",0) == 1)
        {
            Collect2_2.SetActive(true);
            noCollect2_2.SetActive(false);
        }
        else
        {
            Collect2_2.SetActive(false);
            noCollect2_2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("haveCollect2_3",0) == 1)
        {
            Collect2_3.SetActive(true);
            noCollect2_3.SetActive(false);
        }
        else
        {
            Collect2_3.SetActive(false);
            noCollect2_3.SetActive(true);
        }
    }

}
