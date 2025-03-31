using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//HP����X�N���v�g
public class HPController : MonoBehaviour
{
    public GameObject[] Life = new GameObject[5];

    public AudioClip sound1;
    AudioSource audioSource;

    //�n�[�g�̐�
    const int MAXHP = 4;
    int hp;

    // Start is called before the first frame update
    void Start()
    {
        //Component���擾
        audioSource = GetComponent<AudioSource>();
        
        for(int i = Life.Length - 1;i > 2; i--)
        {
            Life[i].SetActive(false);
        }

        hp = 2;
       //Debug.Log(hp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //�Q�[���I�[�o�[����
    public void Damage()
    {
        Life[hp].SetActive(false);
        hp--;

        //�n�[�g���Ȃ��Ȃ�����Q�[���I�[�o�[
        if (hp < 0)
        {
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            GameObject.Find("GameManager").GetComponent<GameManager>().GameStop();
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOverSE();
        }
    }

    public void Heel()
    {
        if(hp == MAXHP)
        {

        }
        else
        {
            audioSource.PlayOneShot(sound1);
            hp++;
            Life[hp].SetActive(true);
        }
    }
}
