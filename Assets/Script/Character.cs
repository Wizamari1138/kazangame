using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//キャラクタースクリプト
public class Character : MonoBehaviour
{
    public GameObject bulletPrefab;

    public AudioClip sound1;
    public AudioClip sound2;
    AudioSource audioSource;

    public bool isGameStart = false;

    public float charaX;

    // Start is called before the first frame update
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posi = this.transform.position;
        charaX = posi.x;

        if (isGameStart)
        {
            //左移動
            if (transform.position.x > -8.0)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Translate(-10.0f*Time.deltaTime, 0, 0);
                }
            }

            //右移動
            if (transform.position.x < 8.3)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Translate(10.0f*Time.deltaTime, 0, 0);
                }
            }

            //弾丸発射
            if (Input.GetKeyDown(KeyCode.Space))
            {
                

                if (GameObject.Find("Canvas").GetComponent<MPController>().mp > 0)
                {
                    Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    GameObject.Find("Canvas").GetComponent<MPController>().mp--;
                    audioSource.PlayOneShot(sound1);
                }
                else if(GameObject.Find("Canvas").GetComponent<MPController>().mp == 0)
                {
                    audioSource.PlayOneShot(sound2);
                }
                
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Heel")
        {


            GameObject.Find("Canvas").GetComponent<HPController>().Heel();

            Destroy(coll.gameObject);

        }


    }


}
