using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    private Player player;
    private int hpMax = 3;
    private int hp = 3;
    public Image imgHp;

    public void SetPlayer(Player player)
    {
        this.player = player;
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
        hp -= damage;
        var rb = gameObject.GetComponent<Rigidbody>();
        var forward = -gameObject.transform.forward.normalized * 500;
        if (hp <= 0)
        {
            forward = -gameObject.transform.forward.normalized * 5000;
            forward.y = 2000;
        }
        rb.AddForce(forward);
        float perHp = (float)hp / (float)hpMax;
        imgHp.fillAmount = perHp;

    }
}
