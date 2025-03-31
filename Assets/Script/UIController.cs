using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

//UI�X�N���v�g
public class UIController : MonoBehaviour
{
    public int score = 0;

    private int highscore; //�n�C�X�R�A�p�ϐ�
    private string key = "HIGH SCORE"; //�n�C�X�R�A�̕ۑ���L�[

    GameObject scoreText;
    GameObject gameOverText;
    GameObject highScore;
    public GameObject retryButton;
    public GameObject titleButton;

    public void GameClear()
    {
        this.gameOverText.GetComponent<Text>().text = "GameClear!";
        retryButton.SetActive(true);
        titleButton.SetActive(true);
    }

    public void AddScore()
    {
        this.score += 10;
    }

    public void GameOver()
    {
        this.gameOverText.GetComponent<Text>().text = "GameOver";
        retryButton.SetActive(true);
        titleButton.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.scoreText = GameObject.Find("Score");
        this.gameOverText = GameObject.Find("GameOver");
        this.highScore = GameObject.Find("HighScore");

        if (GameManager.isEndless)
        {
            highscore = PlayerPrefs.GetInt(key, 0);
            //�ۑ����Ă������n�C�X�R�A���L�[�ŌĂяo���擾���ۑ�����Ă��Ȃ����0�ɂȂ�
            highScore.GetComponent<Text>().text = "HighScore: " + highscore.ToString("D4");
            //�n�C�X�R�A��\��
        }



    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = "Score:" + score.ToString("D4");

        if (GameManager.isEndless)
        {
            if (score > highscore)
            {

                highscore = score;
                //�n�C�X�R�A�X�V

                PlayerPrefs.SetInt(key, highscore);
                //�n�C�X�R�A��ۑ�

                highScore.GetComponent<Text>().text = "HighScore: " + highscore.ToString();
                //�n�C�X�R�A��\��
            }
        }

        
    }
}
