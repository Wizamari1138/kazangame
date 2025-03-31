using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//シーン切り替えスクリプト
public class SceneContoroller : MonoBehaviour
{
    public void HardScene()
    {
        GameManager.isGameMode = 2;
        GameManager.isEndless = false;
        SceneManager.LoadScene("MainScene");
    }

    public void NormalScene()
    {
        GameManager.isGameMode = 1;
        GameManager.isEndless = false;
        SceneManager.LoadScene("MainScene");
    }

    public void EasyScene()
    {
        GameManager.isGameMode = 0;
        GameManager.isEndless = false;
        SceneManager.LoadScene("MainScene");
    }

    public void TitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void EndlessScene()
    {
        GameManager.isGameMode = 3;
        GameManager.isEndless = true;
        SceneManager.LoadScene("EndlessScene");
    }
}
