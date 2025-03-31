using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

//ÉnÅ[ÉgÇÃóéâ∫êßå‰
public class HeartController : MonoBehaviour
{
    float fallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        this.fallSpeed = 0.01f + 0.08f * Random.value;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, -fallSpeed, 0, Space.World);

        if (transform.position.y < -4.5f)
        {
            Destroy(gameObject);
        }
    }
}
