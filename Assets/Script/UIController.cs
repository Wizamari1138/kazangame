using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

//UIスクリプト
public class UIController : MonoBehaviour
{
    public int score = 0;

    private int highscore; //ハイスコア用変数
    private string key = "HIGH SCORE"; //ハイスコアの保存先キー

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
            //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
            highScore.GetComponent<Text>().text = "HighScore: " + highscore.ToString("D4");
            //ハイスコアを表示
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
                //ハイスコア更新

                PlayerPrefs.SetInt(key, highscore);
                //ハイスコアを保存

                highScore.GetComponent<Text>().text = "HighScore: " + highscore.ToString();
                //ハイスコアを表示
            }
        }

        
    }
}
