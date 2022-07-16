using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{

    public GameObject SettingUI;
    public GameObject PlayUI;
    
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
}
