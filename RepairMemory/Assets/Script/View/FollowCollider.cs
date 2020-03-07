using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCollider : MonoBehaviour
{
    protected Partner defenceTarget;
    void Start () { defenceTarget = transform.GetComponentInParent<Partner> (); }
    protected void OnTriggerEnter (Collider collider) { if (collider.gameObject.tag == "Player") { defenceTarget.OnEnterFollowTarget (); } }
    protected void OnTriggerExit (Collider collider) { if (collider.gameObject.tag == "Player") { defenceTarget.OnExitFollowTarget (); } }
}