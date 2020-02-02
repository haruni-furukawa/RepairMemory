using UnityEngine;
using UnityEngine.UI;

public class Enemy5 : Enemy
{
    public UIManager uiManager;
    protected override string GetBulletName()
    {
        return "Enemy5Bullet";
    }

    public void Start ()
    {
        base.Start();
        hp = 20;
        hpMax = 20;
    }
    public void SetUIManager (UIManager uiManager)
    {
        this.uiManager = uiManager;
        uiManager.ShowBossHpBar ();
    }
    public override void Damage (int damage)
    {
        if (hp <= 0)
        {
            return;
        }
        hp -= damage;
        var prefab = (GameObject)Resources.Load("Prefab/EnemyHitEffect");
        objHit.Enqueue(Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform));
        Invoke("DestroyHit", 2);
        var rb = gameObject.GetComponent<Rigidbody> ();
        var forward = -gameObject.transform.forward.normalized * 500;
        if (hp <= 0)
        {
            forward = -gameObject.transform.forward.normalized * 5000;
            forward.y = 2000;
            player.Defeat ();
            uiManager.ShowMessageWindow ("私はメル。……あなたが最初に作ったアンドロイド。", "002", "");
        }
        rb.AddForce (forward);
        float perHp = (float) hp / (float) hpMax;
        uiManager.SetBossHpBar (perHp);
    }
}