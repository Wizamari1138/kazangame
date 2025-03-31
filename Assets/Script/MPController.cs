using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TMPro.Examples;

//MP制御スクリプト
public class MPController : MonoBehaviour
{
    AudioSource audioSource;

    public static bool isCheat = false;

    const int CHEATMP = 2147483647;
    const int MAXMP = 10;
    int healingCount = 1;
    public int mp;
    public bool isGameStart = false;
    public AudioClip sound1;

    GameObject mpText;
    public GameObject Honeysyrup;

    // Start is called before the first frame update
    void Start()
    {
        if (isCheat)
        {
            mp = CHEATMP;
        }
        else
        {
            mp = MAXMP;
        }


        this.mpText = GameObject.Find("MagicPoint");

        audioSource = GetComponent<AudioSource>();

        Debug.Log(mp);
    }

    // Update is called once per frame
    void Update()
    {
        mpText.GetComponent<Text>().text = "MP:" + mp;

        if (isGameStart)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if(healingCount > 0)
                {
                    MPhealing();
                    healingCount--;
                }
                
            }
        }
        
    }

    public void MPhealing()
    {
        mp = MAXMP;
        Honeysyrup.SetActive(false);
        audioSource.PlayOneShot(sound1);
    }
}
