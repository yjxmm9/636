﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer1 : MonoBehaviour
{
    //读取文档
    string[][] ArrayX;//题目数据
    string[] lineArray;//读取到题目数据
    public int topicMax = 0;//最大题数
    private List<bool> isAnserList = new List<bool>();//存放是否答过题的状态

    //加载题目
    public GameObject tipsbtn;//提示按钮
    public Text tipsText;//提示信息
    public List<Toggle> toggleList;//答题Toggle
    public Text indexText;//当前第几题
    public Text TM_Text;//当前题目
    public List<Text> DA_TextList;//选项
    public int topicIndex = 0;//第几题

    //按钮功能及提示信息
    public Button BtnBack;//上一题
    public Button BtnNext;//下一题
    public Button BtnTip;//消息提醒
    public Button BtnJump;//跳转题目
    public InputField jumpInput;//跳转题目
    public Text TextAccuracy;//正确率
    private int anserint = 0;//已经答过几题
    private int isRightNum = 0;//正确题数
    public GameObject Again;
    public GameObject Revive;

    void Awake()
    {
        
        TextCsv();
        LoadAnswer();
    }

    void Start()
    {
        toggleList[0].onValueChanged.AddListener((isOn) => AnswerRightRrongJudgment(isOn,0));
        toggleList[1].onValueChanged.AddListener((isOn) => AnswerRightRrongJudgment(isOn,1));
        toggleList[2].onValueChanged.AddListener((isOn) => AnswerRightRrongJudgment(isOn,2));
        toggleList[3].onValueChanged.AddListener((isOn) => AnswerRightRrongJudgment(isOn,3));

        BtnTip.onClick.AddListener(() => Select_Answer(0));
        BtnBack.onClick.AddListener(() => Select_Answer(1));
        BtnNext.onClick.AddListener(() => Select_Answer(2));
        BtnJump.onClick.AddListener(() => Select_Answer(3));

        
    }


    /*****************读取txt数据******************/
    void TextCsv()
    {
        
        //读取csv二进制文件  

        TextAsset binAsset = Resources.Load("YW2", typeof(TextAsset)) as TextAsset;
        //读取每一行的内容  
        lineArray = binAsset.text.Split('\r');
        //创建二维数组  
        ArrayX = new string[lineArray.Length][];
        
        //把csv中的数据储存在二维数组中  
        for (int i = 0; i < lineArray.Length; i++)
        {
            ArrayX[i] = lineArray[i].Split(':');
        }
        //设置题目状态
        topicMax = lineArray.Length;
        for (int x = 0; x < topicMax + 1; x++)
        {
            isAnserList.Add(false);
        }
    }

    /*****************加载题目******************/
    public void LoadAnswer()
    {
        
        
        for (int i = 0; i < toggleList.Count; i++)
        {
            toggleList[i].isOn = false;
        }
        for (int i = 0; i < toggleList.Count; i++)
        {
            toggleList[i].interactable = true;
        }
        int temp= topicIndex=Random.Range(0, 5);
        tipsbtn.SetActive(false);
        tipsText.text = "";
        indexText.text = "第" + (topicIndex + 1) + "题：";//第几题
        TM_Text.text = ArrayX[temp][1];//题目
        int idx = ArrayX[temp].Length - 3;//有几个选项
        for (int x = 0; x < idx; x++)
        {
            DA_TextList[x].text = ArrayX[temp][x + 2];//选项
        }
    }

    /*****************按钮功能******************/
    void Select_Answer(int index)
    {
        switch (index)
        {
            case 0://提示
                int idx = ArrayX[topicIndex].Length - 1;
                int n = int.Parse(ArrayX[topicIndex][idx]);
                string nM = "";
                switch (n)
                {
                    case 1:
                        nM = "A";
                        break;
                    case 2:
                        nM = "B";
                        break;
                    case 3:
                        nM = "C";
                        break;
                    case 4:
                        nM = "D";
                        break;
                }
                tipsText.text = "<color=#FFAB08FF>" +"正确答案是："+ nM + "</color>";
                break;
            case 1://上一题
                if (topicIndex > 0)
                {
                    topicIndex--;
                    LoadAnswer();
                }
                else
                {
                    tipsText.text = "<color=#27FF02FF>" + "前面已经没有题目了！" + "</color>";
                }
                break;
            case 2://下一题
                if (topicIndex < topicMax-1)
                {
                    topicIndex++;
                    LoadAnswer();
                }
                else
                {
                    tipsText.text = "<color=#27FF02FF>" + "哎呀！已经是最后一题了。" + "</color>";
                }
                break;
            case 3://跳转
                int x = int.Parse(jumpInput.text) - 1;
                if (x >= 0 && x < topicMax)
                {
                    topicIndex = x;
                    jumpInput.text = "";
                    LoadAnswer();
                }
                else
                {
                    tipsText.text = "<color=#27FF02FF>" + "不在范围内！" + "</color>";
                }
                break;
        }
    }

    /*****************题目对错判断******************/
    void AnswerRightRrongJudgment(bool check,int index)
    {
        if (check)
        {
            //判断题目对错
            bool isRight;
            int idx = ArrayX[topicIndex].Length - 1;
            int n = int.Parse(ArrayX[topicIndex][idx]) - 1;
            if (n == index)
            {
                tipsText.text = "<color=#27FF02FF>" + "恭喜你，答对了！" + "</color>";
                isRight = true;
                Revive.SetActive(true);
            }
            else
            {
                tipsText.text = "<color=#FF0020FF>" + "对不起，答错了！" + "</color>";
                isRight = false;
                Again.SetActive(true);
            }
            
            

            //正确率计算
            if (isAnserList[topicIndex])
            {
                tipsText.text = "<color=#FF0020FF>" + "这道题已答过！" + "</color>";
            }
            else
            {
                anserint++;
                if (isRight)
                {
                    isRightNum++;
                }
                isAnserList[topicIndex] = true;
                TextAccuracy.text = "正确率：" + ((float)isRightNum / anserint * 100).ToString("f2") + "%";
            }

            //禁用掉选项
            for (int i = 0; i < toggleList.Count; i++)
            {
                toggleList[i].interactable = false;
            }
        }
    }
}