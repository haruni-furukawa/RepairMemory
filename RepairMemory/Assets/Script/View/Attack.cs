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
            var rb = collider.gameObject.GetComponent<Rigidbody>();
            var forward = - collider.gameObject.transform.forward.normalized * 5000;
            forward.y = 2000;
            //Vector3 force = new Vector3(0.0f, 2000.0f, 5000.0f);
            rb.AddForce(forward);
        }
    }
}
