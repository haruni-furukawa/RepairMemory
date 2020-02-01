using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Player player;

    public void SetPlayer(Player player)
    {
        this.player = player;
        Debug.Log(player);
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
            transform.LookAt(player.transform);
            Debug.Log(player);
        }
    }
}
