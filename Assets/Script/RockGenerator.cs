using UnityEngine;
using System.Collections;

//火山弾出現スクリプト
public class RockGenerator : MonoBehaviour
{
    Character character;
    UIController uiController;
   
    public GameObject meteorPrefab;
    public bool isGameStart = false;
    float meteX;

    void Start()
    {
        character = GameObject.Find("character").GetComponent<Character>();
        uiController = GameObject.Find("Canvas").GetComponent<UIController>();

        InvokeRepeating("GenMeteor", 1, 1.0f);
    }

    void Update()
    {
        
    }

    void GenMeteor()
    {
        if (isGameStart)
        {
            while (true)
            {
                meteX = Random.Range(character.charaX - 3.0f, character.charaX + 3.0f);
                if (-8.0f < meteX && meteX < 8.0f)
                {
                    break;
                }
            }

            Instantiate(meteorPrefab, new Vector3(meteX, 6, 0), Quaternion.identity);
        }
    }
}