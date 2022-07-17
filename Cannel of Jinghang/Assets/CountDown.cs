using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{

    public GameObject CountDownOne;
    public GameObject CountDownTwo;
    public GameObject CountDownThree;
    public GameObject TestBoat;
    public GameObject Player;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
        CountDownOne.SetActive(false);
        CountDownTwo.SetActive(false);
        CountDownThree.SetActive(false);//初始化倒计时界面为false
        
        speed = TestBoat.GetComponent<TestBoatController>().speed;//获取现在的船速度
        TestBoat.GetComponent<TestBoatController>().speed = 0;//将船速设为=0，即达到暂停而timescale不为0
        Player.GetComponent<PlayerController>().speed = 0;//将Player速度设为0

        StartCoroutine(CountDownIE()) ;//开始倒计时协程
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator CountDownIE()
    {
        
        CountDownThree.SetActive(true);
        Time.timeScale = 1;
        yield return new WaitForSeconds(1);
        CountDownThree.SetActive(false);
        CountDownTwo.SetActive(true);

        yield return new WaitForSeconds(1);
        CountDownTwo.SetActive(false);
        CountDownOne.SetActive(true);

        yield return new WaitForSeconds(1);
        CountDownOne.SetActive(false);

        TestBoat.GetComponent<TestBoatController>().speed = speed;
        Player.GetComponent<PlayerController>().speed = speed;//复位速度，开始游戏

    }

}
