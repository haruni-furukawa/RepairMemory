using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
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
            enemy.Damage(10);
        }
    }

}
