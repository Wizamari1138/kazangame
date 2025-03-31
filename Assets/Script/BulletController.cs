using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//弾丸スクリプト
public class BulletController : MonoBehaviour
{
    public GameObject explosionPrefab;   //爆発エフェクトのPrefab
    public GameObject Audio_Object;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 30.0f*Time.deltaTime, 0);

        if (transform.position.y > 5)
        {
            Destroy(gameObject);
        }
    }

    //隕石とのあたり判定
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag != "Player")
        {
            //効果音
            Instantiate(Audio_Object, transform.position, transform.rotation);

            // 衝突したときにスコアを更新する
            GameObject.Find("Canvas").GetComponent<UIController>().AddScore();

            //MPの回復
            GameObject.Find("Canvas").GetComponent<MPController>().mp++;

            // 爆発エフェクトを生成する	
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(coll.gameObject);
            Destroy(gameObject);
        }

        
    }
}
