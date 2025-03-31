using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

//�Q�[���}�l�[�W���[
public class GameManager : MonoBehaviour
{
    public static bool isEndless;
    public static int isGameMode;

    Character character; //�ĂԃX�N���v�g�ɂ����Ȃ���
    RockGenerator rockgenerator;
    BGMController bgmController;
    MPController mpController;
    HeartGenerator heartGenerator;
    AudioSource audioSource;
    TimeController timeController;
    UIController uiController;

    public AudioClip sound1; //�|�[�YSE
    public AudioClip sound2; //�|�[�YSE
    public AudioClip sound3; //�_���[�WSE
    public AudioClip sound4;//�Q�[���I�[�o�[�̌��ʉ�
    public AudioClip sound5;//�Q�[���N���ASE

    //�|�[�Y��ʃI�u�W�F�N�g
    public GameObject PauseCanvas;

    bool isGameStart = false;

    //�G���h���X���[�h�̑��x
    public float endlessSpeed = 0.08f;
    int score = 0; // �X�R�A
    int scoreThreshold = 300; // �X�R�A��臒l
    float intervalDecreaseRate = 0.05f; // ���x���㏸�������

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("character").GetComponent<Character>(); //�t���Ă���X�N���v�g���擾
        rockgenerator = GameObject.Find("MeteoGenerator").GetComponent <RockGenerator>();
        bgmController = GameObject.Find("BGM").GetComponent<BGMController>();
        mpController = GameObject.Find("Canvas").GetComponent<MPController>();
        timeController = GameObject.Find("Canvas").GetComponent<TimeController>();
        uiController = GameObject.Find("Canvas").GetComponent<UIController>();

        if (isEndless)
        {
            heartGenerator = GameObject.Find("HeartGenerator").GetComponent<HeartGenerator>();
        }

        //Component���擾
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStart)
        {
            //�|�[�Y�{�^��
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

    //�Q�[���J�n
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

    //�Q�[���I��
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

    //�|�[�Y
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


    //�ĊJ
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

    //���g���C
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    //�ΎR�e���n�ʂɏՓ�SE
    public void DamageSE()
    {
        audioSource.PlayOneShot(sound3);
    }

    //�G���h���X�̉ΎR�e�̑��x
    public void Endlessfallspeed()
    {
        

        
        score = uiController.score;

        // �X�R�A�ɉ����ďo���Ԋu�𒲐�
        if (score >= scoreThreshold)
        {
            endlessSpeed = endlessSpeed + intervalDecreaseRate;

            // ���̃X�R�A臒l��ݒ�
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
