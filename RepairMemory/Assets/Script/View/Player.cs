using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5.0f;
    private float rotateY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void runUp()
    {
        Debug.Log("runUp");
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    public void runDown()
    {
        transform.position -= transform.forward * speed * Time.deltaTime;
    }
    public void runRight()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
    public void runLeft()
    {
        transform.position -= transform.right * speed * Time.deltaTime;
    }

    public void turnRight()
    {
        transform.rotation = Quaternion.Euler(0, rotateY, 0);
        rotateY++;
    }
    public void turnLeft()
    {
        transform.rotation = Quaternion.Euler(0, rotateY, 0);
        rotateY--;
    }


    //if (bKey)
    //{
    //    this.animator.SetBool(isRunning, true);
    //}
    //else
    //{
    //    this.animator.SetBool(isRunning, false);
    //}
}
