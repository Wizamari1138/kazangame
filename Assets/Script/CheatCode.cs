using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

//チートコード
public class CheatCode : MonoBehaviour
{
    private bool isTyping;
    private float timer;
    private String pass;
    private String command;
    bool isCheat = false;

    AudioSource audioSource;
    public AudioClip sound1;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        pass = "上上下下左右左右AB";
        MPController.isCheat = false;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            isTyping = false;
            command = "";
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isTyping == false)
        {
            timer = 3.0f;
            isTyping = true;
            command = "上";
            Debug.Log(KeyCode.UpArrow);
        }
        else if (isTyping)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) 
            {
                command = command + "上";
                Debug.Log(KeyCode.UpArrow);
            }
                
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                command = command + "下";
                Debug.Log(KeyCode.DownArrow);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                command = command + "右";
                Debug.Log(KeyCode.DownArrow);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                command = command + "左";
                Debug.Log(KeyCode.DownArrow);
            }

            if (Input.GetKeyDown(KeyCode.A)) 
            { 
                command = command + "A";
                Debug.Log(KeyCode.A);
            }
           
            if (Input.GetKeyDown(KeyCode.B))
            {
                command = command + "B";
                Debug.Log(KeyCode.B);
            }
              
        }

        if (command == pass)
        {
            if (!isCheat)
            {
                MPController.isCheat = true;
                isCheat = true;
                Debug.Log("チートコード起動");
                audioSource.PlayOneShot(sound1);
                command = "";
            }
            else
            {
                MPController.isCheat = false;
                isCheat = false;
                Debug.Log("チートコード起動");
                audioSource.PlayOneShot(sound1);
                command = "";
            }

            
        }
        else
        {

        }
            
    }
}
