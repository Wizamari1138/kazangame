using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BGM�Đ���~����
public class BGMController : MonoBehaviour
{
    AudioSource audioSource;

    


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        audioSource.Pause();
    }

    public void ResumeGame()
    {
        audioSource.UnPause();
    }

    public void GameStop()
    {
        audioSource.Stop();
    }
}
