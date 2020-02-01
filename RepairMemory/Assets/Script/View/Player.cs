using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5.0f;
    private float rotateY = 0.0f;
    public Animator animator = null;
    public GameObject attack = null;
    public GameObject attack2 = null;
    public GameObject skill = null;
    private int hp = 10;
    private int maxHp = 10;
    private int sp = 0;
    private int maxSp = 10;

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
    }
    public void AttackEnd()
    {
        animator.SetBool("attack", false);
        attack.SetActive(false);
    }
    public void AttackImpact()
    {
        attack.SetActive(true);
    }

    public void Attack2()
    {
        animator.SetBool("attack2", true);
    }
    public void Attack2Start()
    {
    }
    public void Attack2End()
    {
        animator.SetBool("attack2", false);
        attack2.SetActive(false);
    }
    public void Attack2Impact()
    {
        attack2.SetActive(true);
    }

    public void Skill()
    {
        animator.SetBool("skill", true);
    }
    public void SkillStart()
    {
    }
    public void SkillEnd()
    {
        animator.SetBool("skill", false);
        skill.SetActive(false);
    }
    public void SkillImpact()
    {
        skill.SetActive(true);
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
