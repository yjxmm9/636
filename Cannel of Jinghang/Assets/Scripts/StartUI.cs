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
        
        SettingUI.SetActive(false);//�����ʼ������Ϊ����ʾ
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
        
        SettingUI.SetActive(true);//�����ʼ������Ϊ����ʾ
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
        CollectionUI.transform.Find("Panel").gameObject.SetActive(true);//���ռ�ƷUI�ĵ�һҳ
        MainMenu.SetActive(false);//�ر�MainMene

    }

    public void NextOnOne()
    {
        GameObject CollectionOneUI = GameObject.Find("CollectionOneUI");
        CollectionOneUI.transform.Find("Panel").gameObject.SetActive(false);//�ر��ռ�ƷUI�ĵ�һҳ
        GameObject CollectionTwoUI = GameObject.Find("CollectionTwoUI");
        CollectionTwoUI.transform.Find("Panel").gameObject.SetActive(true);//���ռ�ƷUI�ĵڶ�ҳ
    }

    public void NextOnTwo()
    {
        GameObject CollectionTwoUI = GameObject.Find("CollectionTwoUI");
        CollectionTwoUI.transform.Find("Panel").gameObject.SetActive(false);//�ر��ռ�ƷUI�ĵڶ�ҳ
        GameObject CollectionThreeUI = GameObject.Find("CollectionThreeUI");
        CollectionThreeUI.transform.Find("Panel").gameObject.SetActive(true);//���ռ�ƷUI�ĵ���ҳ
    }

    public void ReturnButton()
    {
        GameObject CollectionUI = GameObject.Find("CollectionOneUI");
        CollectionUI.transform.Find("Panel").gameObject.SetActive(false);//�ر��ռ�ƷUI�ĵ�һҳ
        MainMenu.SetActive(true);//��MainMene
    }

    public void ReturnOnTwo()
    {
        GameObject CollectionOneUI = GameObject.Find("CollectionOneUI");
        CollectionOneUI.transform.Find("Panel").gameObject.SetActive(true);//���ռ�ƷUI�ĵ�һҳ
        GameObject CollectionTwoUI = GameObject.Find("CollectionTwoUI");
        CollectionTwoUI.transform.Find("Panel").gameObject.SetActive(false);//�ر��ռ�ƷUI�ĵڶ�ҳ
    }

    public void ReturnOnThree()
    {
        GameObject CollectionTwoUI = GameObject.Find("CollectionTwoUI");
        CollectionTwoUI.transform.Find("Panel").gameObject.SetActive(true);//���ռ�ƷUI�ĵڶ�ҳ
        GameObject CollectionThreeUI = GameObject.Find("CollectionThreeUI");
        CollectionThreeUI.transform.Find("Panel").gameObject.SetActive(false);//�ر��ռ�ƷUI�ĵ���ҳ
    }

}
