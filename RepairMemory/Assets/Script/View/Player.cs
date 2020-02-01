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
    public UIManager uiManager = null;
    private int hp = 10;
    private int hpMax = 10;
    private int sp = 0;
    private int spMax = 10;
    private int banishCount = 0;

    // Start is called before the first frame update
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        uiManager.SetHpBar ((float) hp / (float) hpMax);
        uiManager.SetSpBar ((float) sp / (float) spMax);
    }
    public void IncreaseSp ()
    {
        sp++;
        if (sp > spMax)
        {
            sp = spMax;
        }
    }
    public void runUp ()
    {
        if (hp <= 0)
        {
            return;
        }
        transform.position += transform.forward * speed * Time.deltaTime;
        animator.SetBool ("run", true);
    }
    public void runDown ()
    {
        if (hp <= 0)
        {
            return;
        }
        transform.position -= transform.forward * speed * Time.deltaTime;
        animator.SetBool ("run", true);
    }
    public void runRight ()
    {
        if (hp <= 0)
        {
            return;
        }
        transform.position += transform.right * speed * Time.deltaTime;
        animator.SetBool ("run", true);
    }
    public void runLeft ()
    {
        if (hp <= 0)
        {
            return;
        }
        transform.position -= transform.right * speed * Time.deltaTime;
        animator.SetBool ("run", true);
    }
    public void idle ()
    {
        animator.SetBool ("run", false);
    }

    public void turnRight ()
    {
        if (hp <= 0)
        {
            return;
        }
        transform.rotation = Quaternion.Euler (0, rotateY, 0);
        rotateY++;
    }
    public void turnLeft ()
    {
        if (hp <= 0)
        {
            return;
        }
        transform.rotation = Quaternion.Euler (0, rotateY, 0);
        rotateY--;
    }

    public void Attack ()
    {
        animator.SetBool ("attack", true);
    }
    public void AttackStart ()
    { }
    public void AttackEnd ()
    {
        animator.SetBool ("attack", false);
        attack.SetActive (false);
    }
    public void AttackImpact ()
    {
        attack.SetActive (true);
    }

    public void Attack2 ()
    {
        animator.SetBool ("attack2", true);
    }
    public void Attack2Start ()
    { }
    public void Attack2End ()
    {
        animator.SetBool ("attack2", false);
        attack2.SetActive (false);
    }
    public void Attack2Impact ()
    {
        attack2.SetActive (true);
    }

    public void Skill ()
    {
        if (sp == spMax)
        {
            animator.SetBool ("skill", true);
            sp = 0;
        }
    }
    public void SkillStart ()
    { }
    public void SkillEnd ()
    {
        animator.SetBool ("skill", false);
        skill.SetActive (false);
    }
    public void SkillImpact ()
    {
        skill.SetActive (true);
    }
    public void Defeat ()
    {
        banishCount++;
        uiManager.SetBanishCount (banishCount);
    }
    public void Damage (int damage)
    {
        animator.SetBool ("damage", true);
        hp -= damage;
        if (hp <= 0)
        {
            animator.SetBool ("death", true);
            uiManager.ShowGameOver ();
        }
    }
    public void DamageEnd (int damage)
    {
        animator.SetBool ("damage", false);
    }
    public void OnTriggerEnter (Collider collision)
    {
        //Debug.Log("Player.OnTriggerEnter");
    }
}