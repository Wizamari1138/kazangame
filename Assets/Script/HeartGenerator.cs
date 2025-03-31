using System.Collections;
using UnityEngine;

//ハートの出現スクリプト
public class HeartGenerator : MonoBehaviour
{
    public GameObject heartPrefab;
    public bool isGameStart = false;
    float meteX;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenHeart", 1, 1.0f);
    }

    void GenHeart()
    {
        if (isGameStart)
        {
            int ran = (int)Random.Range(1, 30);

            if (ran == 5)
            {
                meteX = Random.Range(-8.0f, 8.0f);

                Instantiate(heartPrefab, new Vector3(meteX, 6, 0), Quaternion.identity);
            }
            else
            {

            }
            
        }
    }
    
}
