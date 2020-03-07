using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partner : MonoBehaviour
{
    public enum MoveMode
    {
        Idle = 1,
        Follow = 2
    }
    public float speed = 15.0f;
    public Animator animator = null;
    public Transform followTarget;
    protected Rigidbody rb;
    protected MoveMode currentMoveMode;

    void Start ()
    {
        rb = this.GetComponent<Rigidbody> ();
        currentMoveMode = MoveMode.Follow;
    }

    void Update () { DoAutoMovement (); }
    public void Follow ()
    {
        Quaternion move_rotation = Quaternion.LookRotation (followTarget.transform.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.Lerp (transform.rotation, move_rotation, 0.1f);
        transform.position += transform.forward * speed * Time.deltaTime;
        animator.SetBool ("run", true);
    }
    public void Idle () { animator.SetBool ("run", false); }
    protected void DoAutoMovement ()
    {
        switch (currentMoveMode)
        {
            case MoveMode.Idle:
                Idle ();
                break;
            case MoveMode.Follow:
                if (followTarget != null) { Follow (); }
                break;
        }
    }
    public void OnEnterFollowTarget () { if (currentMoveMode == MoveMode.Follow) { currentMoveMode = MoveMode.Idle; } }
    public void OnExitFollowTarget () { if (currentMoveMode == MoveMode.Idle) { currentMoveMode = MoveMode.Follow; } }
}