using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�������ԁA�J�E���g�_�E���X�N���v�g
public class TimeController : MonoBehaviour
{
    //�^�C�}�[�ƃJ�E���g�_�E���I�u�W�F�N�g
    GameObject timerText;
    GameObject countText;
   

    GameManager gamemaneger;

    bool isGameStart = true;
   
    //��������
    float totalTime = 60;
    int retime;
    //�J�E���g�_�E��
    float countdown = 3f;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        //�I�u�W�F�N�g�̓ǂݍ���
        
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
            //�������ԕ\��
            timerText.GetComponent<Text>().text = "�c��" + totalTime.ToString() + "�b";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown >= 1)
        {
            //�J�E���g�_�E���v�Z
            countdown -= Time.deltaTime;
            count = (int)countdown;
            //�J�E���g�_�E���\��
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
                
                //�������Ԍv�Z
                totalTime -= Time.deltaTime;
                retime = (int)totalTime;

                //�c�莞�Ԃ�0�b�S��������s
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
                        //�L�����N�^�[��覐΂̋N��
                        gamemaneger.GameStart();
                        isGameStart = false;
                    }
                }

                //�������ԕ\��
                timerText.GetComponent<Text>().text = "�c��" + retime.ToString() + "�b";
            }
            else
            {

                if (isGameStart)
                {
                    //�L�����N�^�[��覐΂̋N��
                    gamemaneger.GameStart();
                    isGameStart = false;
                }
            }

            
        }
        
    }
}
