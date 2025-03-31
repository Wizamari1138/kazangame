using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//制限時間、カウントダウンスクリプト
public class TimeController : MonoBehaviour
{
    //タイマーとカウントダウンオブジェクト
    GameObject timerText;
    GameObject countText;
   

    GameManager gamemaneger;

    bool isGameStart = true;
   
    //制限時間
    float totalTime = 60;
    int retime;
    //カウントダウン
    float countdown = 3f;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        //オブジェクトの読み込み
        
        this.countText = GameObject.Find("CountText");

        if (!GameManager.isEndless)
        {
            this.timerText = GameObject.Find("Timer");
        }
        else
        {
            
        }

        gamemaneger = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (!GameManager.isEndless)
        {
            //制限時間表示
            timerText.GetComponent<Text>().text = "残り" + totalTime.ToString() + "秒";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown >= 1)
        {
            //カウントダウン計算
            countdown -= Time.deltaTime;
            count = (int)countdown;
            //カウントダウン表示
            countText.GetComponent<Text>().text = count.ToString();
        }
        else if (countdown < 1 && countdown > -1)
        {
            countText.GetComponent<Text>().text = "START!";
            countdown -= Time.deltaTime;


        }
        else if (countdown <= -1)
        {
            countText.GetComponent<Text>().text = "";

            if (!GameManager.isEndless)
            {
                
                //制限時間計算
                totalTime -= Time.deltaTime;
                retime = (int)totalTime;

                //残り時間が0秒担ったら実行
                if (retime <= 0)
                {
                    GameObject.Find("Canvas").GetComponent<UIController>().GameClear();

                    if (!isGameStart)
                    {
                        gamemaneger.GameStop();
                        gamemaneger.GameClearSE();
                        isGameStart = true;
                    }
                }
                else
                {
                    if (isGameStart)
                    {
                        //キャラクターと隕石の起動
                        gamemaneger.GameStart();
                        isGameStart = false;
                    }
                }

                //制限時間表示
                timerText.GetComponent<Text>().text = "残り" + retime.ToString() + "秒";
            }
            else
            {

                if (isGameStart)
                {
                    //キャラクターと隕石の起動
                    gamemaneger.GameStart();
                    isGameStart = false;
                }
            }

            
        }
        
    }
}
