using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{

    public GameObject SettingUI;
    public GameObject PlayUI;
    public GameObject MainMenu;
    
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
        GameObject CollectionUI = GameObject.Find("CollectionOneUI");
        CollectionUI.transform.Find("Panel").gameObject.SetActive(true);//打开收集品UI的第一页
        MainMenu.SetActive(false);//关闭MainMene

    }

    public void NextOnOne()
    {
        GameObject CollectionOneUI = GameObject.Find("CollectionOneUI");
        CollectionOneUI.transform.Find("Panel").gameObject.SetActive(false);//关闭收集品UI的第一页
        GameObject CollectionTwoUI = GameObject.Find("CollectionTwoUI");
        CollectionTwoUI.transform.Find("Panel").gameObject.SetActive(true);//打开收集品UI的第二页
    }

    public void NextOnTwo()
    {
        GameObject CollectionTwoUI = GameObject.Find("CollectionTwoUI");
        CollectionTwoUI.transform.Find("Panel").gameObject.SetActive(false);//关闭收集品UI的第二页
        GameObject CollectionThreeUI = GameObject.Find("CollectionThreeUI");
        CollectionThreeUI.transform.Find("Panel").gameObject.SetActive(true);//打开收集品UI的第三页
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
    }

    public void ReturnOnThree()
    {
        GameObject CollectionTwoUI = GameObject.Find("CollectionTwoUI");
        CollectionTwoUI.transform.Find("Panel").gameObject.SetActive(true);//打开收集品UI的第二页
        GameObject CollectionThreeUI = GameObject.Find("CollectionThreeUI");
        CollectionThreeUI.transform.Find("Panel").gameObject.SetActive(false);//关闭收集品UI的第三页
    }

}
