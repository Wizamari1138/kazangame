using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

//ゲームマネージャー
public class GameManager : MonoBehaviour
{
    public static bool isEndless;
    public static int isGameMode;

    Character character; //呼ぶスクリプトにあだなつける
    RockGenerator rockgenerator;
    BGMController bgmController;
    MPController mpController;
    HeartGenerator heartGenerator;
    AudioSource audioSource;
    TimeController timeController;
    UIController uiController;

    public AudioClip sound1; //ポーズSE
    public AudioClip sound2; //ポーズSE
    public AudioClip sound3; //ダメージSE
    public AudioClip sound4;//ゲームオーバーの効果音
    public AudioClip sound5;//ゲームクリアSE

    //ポーズ画面オブジェクト
    public GameObject PauseCanvas;

    bool isGameStart = false;

    //エンドレスモードの速度
    public float endlessSpeed = 0.08f;
    int score = 0; // スコア
    int scoreThreshold = 300; // スコアの閾値
    float intervalDecreaseRate = 0.05f; // 速度を上昇させる量

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("character").GetComponent<Character>(); //付いているスクリプトを取得
        rockgenerator = GameObject.Find("MeteoGenerator").GetComponent <RockGenerator>();
        bgmController = GameObject.Find("BGM").GetComponent<BGMController>();
        mpController = GameObject.Find("Canvas").GetComponent<MPController>();
        timeController = GameObject.Find("Canvas").GetComponent<TimeController>();
        uiController = GameObject.Find("Canvas").GetComponent<UIController>();

        if (isEndless)
        {
            heartGenerator = GameObject.Find("HeartGenerator").GetComponent<HeartGenerator>();
        }

        //Componentを取得
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStart)
        {
            //ポーズボタン
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Time.timeScale == 1)
                {
                    PauseGame();
                }
                else if (Time.timeScale == 0)
                {
                    ResumeGame();
                }
            }

        }

        if (isEndless)
        {
            Endlessfallspeed();
        }

        

    }

    //ゲーム開始
    public void GameStart()
    {
        character.isGameStart = true;
        rockgenerator.isGameStart = true;
        mpController.isGameStart = true;
        this.isGameStart = true;

        if (isEndless)
        {
            heartGenerator.isGameStart = true;
        }

        Time.timeScale = 1;
    }

    //ゲーム終了
    public void GameStop()
    {
        character.isGameStart = false;
        rockgenerator.isGameStart = false;
        mpController.isGameStart = false;

        if (isEndless)
        {
            heartGenerator.isGameStart = true;
        }

        bgmController.GameStop();

        Time.timeScale = 0;
    }

    //ポーズ
    public void PauseGame()
    {
        audioSource.PlayOneShot(sound1);
        character.isGameStart = false;
        mpController.isGameStart= false;
        bgmController.PauseGame();

        PauseCanvas.SetActive(true);

        Time.timeScale = 0;
        Debug.Log(Time.timeScale);
    }


    //再開
    public void ResumeGame()
    {
        audioSource.PlayOneShot(sound2);
        character.isGameStart = true;
        mpController.isGameStart= true;
        bgmController.ResumeGame();

        PauseCanvas.SetActive(false);

        Time.timeScale = 1;
        Debug.Log(Time.timeScale);
    }

    //リトライ
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    //火山弾が地面に衝突SE
    public void DamageSE()
    {
        audioSource.PlayOneShot(sound3);
    }

    //エンドレスの火山弾の速度
    public void Endlessfallspeed()
    {
        

        
        score = uiController.score;

        // スコアに応じて出現間隔を調整
        if (score >= scoreThreshold)
        {
            endlessSpeed = endlessSpeed + intervalDecreaseRate;

            // 次のスコア閾値を設定
            scoreThreshold += 300;

            Debug.Log(endlessSpeed);
        }
    }

    public void GameOverSE()
    {
        audioSource.PlayOneShot(sound4);
    }

    public void GameClearSE()
    {
        audioSource.PlayOneShot(sound5);
    }

}
