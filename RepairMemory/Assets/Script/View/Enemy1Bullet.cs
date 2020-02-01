using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Bullet : MonoBehaviour
{
    float speed = 30;
    float totalTime = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = gameObject.transform.rotation * new Vector3(0, 0, speed);
        gameObject.transform.position += velocity * Time.deltaTime;
        totalTime += Time.deltaTime;
        if (totalTime >= 5.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
