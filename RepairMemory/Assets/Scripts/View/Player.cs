using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 15.0f;
    private float rotateSpeed = 75.0f;
    private float RayLength = 2.5f;
    private float rotateY = 0.0f;
    public Animator animator = null;
    public GameObject attack = null;
    public GameObject attack2 = null;
    public GameObject skill = null;
    public UIManager uiManager = null;
    public EventManager eventManager = null;
    public Queue<GameObject> objSkill = null;
    public Queue<GameObject> objSkill2 = null;
    public LayerMask layermask;
    public AudioClip soundSkill;
    public AudioClip soundSlash;
    public AudioClip soundSlash2;
    public AudioClip soundDamage;
    private int hp = 10;
    private int hpMax = 10;
    private int sp = 0;
    private int spMax = 10;
    private int banishCount = 0;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        objSkill = new Queue<GameObject>();
        objSkill2 = new Queue<GameObject>();
        audioSource = GetComponent<AudioSource>();
        uiManager.SetMemoryParts(0);
    }

    // Update is called once per frame
    void Update()
    {
        uiManager.SetHpBar((float)hp / (float)hpMax);
        uiManager.SetSpBar((float)sp / (float)spMax);
    }
    public void IncreaseSp()
    {
        sp++;
        if (sp > spMax)
        {
            sp = spMax;
        }
    }
    private bool IsMoveability(Vector3 direction)
    {
        return !Physics.Raycast(transform.position, direction, RayLength, layermask, QueryTriggerInteraction.Ignore);
    }
    public void runUp()
    {
        if (hp <= 0)
        {
            return;
        }
        if (IsMoveability(transform.forward))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        animator.SetBool("run", true);
    }
    public void runDown()
    {
        if (hp <= 0)
        {
            return;
        }
        if (IsMoveability(-transform.forward))
        {
            transform.position -= transform.forward * moveSpeed * Time.deltaTime;
        }
        animator.SetBool("run", true);
    }
    public void runRight()
    {
        if (hp <= 0)
        {
            return;
        }
        if (IsMoveability(transform.right))
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
        animator.SetBool("run", true);
    }
    public void runLeft()
    {
        if (hp <= 0)
        {
            return;
        }
        if (IsMoveability(-transform.right))
        {
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }
        animator.SetBool("run", true);
    }
    public void idle()
    {
        animator.SetBool("run", false);
    }

    public void turnRight()
    {
        if (hp <= 0)
        {
            return;
        }
        transform.rotation = Quaternion.Euler(0, rotateY, 0);
        rotateY += Time.deltaTime * rotateSpeed;
    }
    public void turnLeft()
    {
        if (hp <= 0)
        {
            return;
        }
        transform.rotation = Quaternion.Euler(0, rotateY, 0);
        rotateY -= Time.deltaTime * rotateSpeed;
    }

    public void Attack()
    {
        animator.SetBool("attack", true);
    }
    public void AttackStart() { }
    public void AttackEnd()
    {
        animator.SetBool("attack", false);
        attack.SetActive(false);
    }
    public void AttackImpact()
    {
        audioSource.PlayOneShot(soundSlash);
        attack.SetActive(true);
    }

    public void Attack2()
    {
        animator.SetBool("attack2", true);
    }
    public void Attack2Start() { }
    public void Attack2End()
    {
        animator.SetBool("attack2", false);
        attack2.SetActive(false);
    }
    public void Attack2Impact()
    {
        audioSource.PlayOneShot(soundSlash2);
        attack2.SetActive(true);
    }
    public void Skill()
    {
        if (sp == spMax)
        {
            var prefab = (GameObject)Resources.Load(ResourceConst.EFFECTS_PREFABS_PATH + "SkillEffect1");
            objSkill.Enqueue(Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform));
            Invoke("DestroySkill", 5);
            animator.SetBool("skill", true);
            sp = 0;
        }
    }
    public void SkillStart() { }
    public void SkillEnd()
    {
        animator.SetBool("skill", false);
        skill.SetActive(false);
    }
    public void SkillImpact()
    {
        var prefab = (GameObject)Resources.Load(ResourceConst.EFFECTS_PREFABS_PATH + "SkillEffect2");
        objSkill2.Enqueue(Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform));
        audioSource.PlayOneShot(soundSkill);
        Invoke("DestroySkill2", 5);
        skill.SetActive(true);
    }
    public void Defeat()
    {
        banishCount++;
        eventManager.DefeatEvent(banishCount, HealHp);
    }

    public void HealHp() { hp = hpMax; }
    public void Damage(int damage)
    {
        animator.SetBool("damage", true);
        hp -= damage;
        audioSource.PlayOneShot(soundDamage);
        if (hp <= 0)
        {
            animator.SetBool("death", true);
            uiManager.ShowGameOver();
        }
    }
    public void DamageEnd(int damage)
    {
        animator.SetBool("damage", false);
    }
    public void OnTriggerEnter(Collider collision)
    {

    }
    public void DestroySkill()
    {
        Destroy(objSkill.Dequeue());
    }
    public void DestroySkill2()
    {
        Destroy(objSkill2.Dequeue());
    }
}