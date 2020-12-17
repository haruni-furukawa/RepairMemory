using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = player.transform.localEulerAngles;
        Vector3 newPosition = player.transform.position - transform.forward.normalized * 7;
        newPosition.y += 3;
        transform.position = newPosition;
    }
}
