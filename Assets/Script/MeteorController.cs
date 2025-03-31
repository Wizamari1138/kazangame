using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

//âŒéRíeóéâ∫êßå‰
public class MeteorController : MonoBehaviour
{
    float fallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        

        switch (GameManager.isGameMode){
            case 0:
                this.fallSpeed = 0.01f + 0.08f * Random.value;
                break;
            case 1:
                this.fallSpeed = 0.01f + 0.15f * Random.value;
                break;
            case 2:
                this.fallSpeed = 0.01f + 0.3f * Random.Range(0.5f,1.0f);
                break;
            case 3:
                this.fallSpeed = 0.01f + GameObject.Find("GameManager").GetComponent<GameManager>().endlessSpeed * Random.value;
                break;
        }

        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
            transform.Translate(0, -fallSpeed, 0, Space.World);

            if (transform.position.y < -4.5f)
            {
                GameObject.Find("Canvas").GetComponent<HPController>().Damage();
                GameObject.Find("GameManager").GetComponent<GameManager>().DamageSE();
                Destroy(gameObject);
            }
       
        
    }
}
