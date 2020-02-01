using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Player player;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.runUp();
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.runDown();
        }

        if (Input.GetKey(KeyCode.D))
        {
            player.runRight();
        }

        if (Input.GetKey(KeyCode.A))
        {
            player.runLeft();
        }

    }
}
