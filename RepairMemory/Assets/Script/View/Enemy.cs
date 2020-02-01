using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Player player;

    public Enemy(Player player)
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
        transform.LookAt(player.transform);
    }
}
