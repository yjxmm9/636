using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUI : MonoBehaviour
{
    public GameObject lock2;
    public GameObject lock3;
    private void Start()
    {
        if (PlayerPrefs.GetInt("r1success",0)==1)
        {
            lock2.SetActive(false);
        }
        else if(PlayerPrefs.GetInt("r2success", 0) == 1)
        {
            lock3.SetActive(false);
        }
    }
    public void Rank1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void Rank2()
    {
        if (PlayerPrefs.GetInt("r1success", 0) != 1)
        {
            return;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    public void Rank3()
    {
        if (PlayerPrefs.GetInt("r2success", 0) != 1)
        {
            return;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

    public void Back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
