using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
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
        var enemy = collider.gameObject.GetComponent<Enemy>();
        if(enemy != null)
        {
            Debug.Log("敵に当たりました");
            var rb = collider.gameObject.GetComponent<Rigidbody>();
            Debug.Log(rb);
            Vector3 force = new Vector3(0.0f, 2000.0f, 5000.0f);
            rb.AddForce(force);
        }
    }
}
