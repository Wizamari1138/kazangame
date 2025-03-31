using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�e�ۃX�N���v�g
public class BulletController : MonoBehaviour
{
    public GameObject explosionPrefab;   //�����G�t�F�N�g��Prefab
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

    //覐΂Ƃ̂����蔻��
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag != "Player")
        {
            //���ʉ�
            Instantiate(Audio_Object, transform.position, transform.rotation);

            // �Փ˂����Ƃ��ɃX�R�A���X�V����
            GameObject.Find("Canvas").GetComponent<UIController>().AddScore();

            //MP�̉�
            GameObject.Find("Canvas").GetComponent<MPController>().mp++;

            // �����G�t�F�N�g�𐶐�����	
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(coll.gameObject);
            Destroy(gameObject);
        }

        
    }
}
