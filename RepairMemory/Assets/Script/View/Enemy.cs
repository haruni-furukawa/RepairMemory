using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Player player;

    public void SetPlayer(Player player)
    {
        this.player = player;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 常にプレイヤーを見る
        if (player != null)
        {
            var targetPos = player.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
        }
        //var rb = gameObject.GetComponent<Rigidbody>();
        //Vector3 force = new Vector3(0.0f, 0.0f, 20.0f);
        //rb.AddForce(force);

    }
}
