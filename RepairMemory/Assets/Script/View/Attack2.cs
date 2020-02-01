using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2 : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("OnTriggerEnter");
        var enemy = collider.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            player.IncreaseSp();
            enemy.Damage(1);
        }
    }

}
