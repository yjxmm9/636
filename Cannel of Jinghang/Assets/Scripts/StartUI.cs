using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{

    public GameObject SettingUI;
    
    // Start is called before the first frame update
    void Start()
    {
        
        SettingUI.SetActive(false);//将其初始化设置为不显示
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
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

    
}
