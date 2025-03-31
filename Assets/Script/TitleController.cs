using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//タイトルボタン表示スクリプト
public class TitleController : MonoBehaviour
{
    public GameObject easyButton;
    public GameObject normalButton;
    public GameObject hardButton;
    public GameObject newgameButton;
    public GameObject endlessButton;
    public GameObject backButton;

    public void Newgame()
    {
        easyButton.SetActive(true);
        normalButton.SetActive(true);
        hardButton.SetActive(true);
        backButton.SetActive(true);
        newgameButton.SetActive(false);
        endlessButton.SetActive(false);
    }

    public void Back()
    {
        easyButton.SetActive(false);
        normalButton.SetActive(false);
        hardButton.SetActive(false);
        newgameButton.SetActive(true);
        endlessButton.SetActive(true);
        backButton.SetActive(false);
    }
}
