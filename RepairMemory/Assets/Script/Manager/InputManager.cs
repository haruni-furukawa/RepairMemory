using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Player player;

    void Update()
    {
        bool bRun = false;
        if (Input.GetKey(KeyCode.W))
        {
            player.runUp();
            bRun = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.runDown();
            bRun = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            player.runRight();
            bRun = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            player.runLeft();
            bRun = true;
        }

        if (Input.GetKey(KeyCode.E))
        {
            player.turnRight();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            player.turnLeft();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            player.Attack();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            player.Attack2();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            player.Skill();
        }
        if (!bRun) 
        {
            player.idle();
        
        }

    }
}
