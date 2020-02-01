using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5.0f;
    private float rotateY = 0.0f;
    public Animator animator = null;
    public GameObject attack = null;

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
        transform.position += transform.forward * speed * Time.deltaTime;
        animator.SetBool("run", true);
    }
    public void runDown()
    {
        transform.position -= transform.forward * speed * Time.deltaTime;
        animator.SetBool("run", true);
    }
    public void runRight()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        animator.SetBool("run", true);
    }
    public void runLeft()
    {
        transform.position -= transform.right * speed * Time.deltaTime;
        animator.SetBool("run", true);
    }
    public void idle()
    {
        animator.SetBool("run", false);
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
    public void Attack()
    {
        animator.SetBool("attack", true);
    }
    public void AttackStart()
    {
        animator.SetBool("attack", false);
    }
    public void AttackEnd()
    {
        attack.SetActive(false);
    }
    public void Impact()
    {
        attack.SetActive(true);
    }
    public void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Player.OnTriggerEnter");
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
