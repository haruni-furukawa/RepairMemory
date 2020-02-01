using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Player player;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player.runUp();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            player.runDown();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.runRight();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.runLeft();
        }

    }
}
