using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

//�`�[�g�R�[�h
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

        pass = "��㉺�����E���EAB";
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
            command = "��";
            Debug.Log(KeyCode.UpArrow);
        }
        else if (isTyping)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) 
            {
                command = command + "��";
                Debug.Log(KeyCode.UpArrow);
            }
                
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                command = command + "��";
                Debug.Log(KeyCode.DownArrow);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                command = command + "�E";
                Debug.Log(KeyCode.DownArrow);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                command = command + "��";
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
                Debug.Log("�`�[�g�R�[�h�N��");
                audioSource.PlayOneShot(sound1);
                command = "";
            }
            else
            {
                MPController.isCheat = false;
                isCheat = false;
                Debug.Log("�`�[�g�R�[�h�N��");
                audioSource.PlayOneShot(sound1);
                command = "";
            }

            
        }
        else
        {

        }
            
    }
}
