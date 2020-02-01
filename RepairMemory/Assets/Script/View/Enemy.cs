using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    private Player player;
    private int hpMax = 3;
    private int hp = 3;
    public Image imgHp;
    private float nextTime = 0.0f;
    private float totalTime = 0.0f;

    public void SetPlayer(Player player)
    {
        this.player = player;
    }
    // Start is called before the first frame update
    void Start()
    {
        nextTime = Random.Range(5.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        nextTime -= Time.deltaTime;
        if (nextTime <= 0)
        {
            var prefab = (GameObject)Resources.Load("Prefab/Enemy1Bullet");
            var objEnemy = Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);
            nextTime = Random.Range(1.0f, 5.0f);
        }
        // 常にプレイヤーを見る
        if (player != null)
        {
            var targetPos = player.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
        }
        //float perHp = (float)hp / (float)hpMax;
        //imgHp.fillAmount = perHp;
        //var rb = gameObject.GetComponent<Rigidbody>();
        //Vector3 force = new Vector3(0.0f, 0.0f, 20.0f);
        //rb.AddForce(force);

    }

    public void Damage(int damage)
    {
        if(hp <= 0)
        {
            return;
        }
        nextTime = Random.Range(2.0f, 6.0f);
        hp -= damage;
        var rb = gameObject.GetComponent<Rigidbody>();
        var forward = -gameObject.transform.forward.normalized * 500;
        if (hp <= 0)
        {
            forward = -gameObject.transform.forward.normalized * 5000;
            forward.y = 2000;
            player.Defeat();
        }
        rb.AddForce(forward);
        float perHp = (float)hp / (float)hpMax;
        imgHp.fillAmount = perHp;

    }
}
