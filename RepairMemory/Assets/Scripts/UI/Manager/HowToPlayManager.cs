using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HowToPlayManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _transitionFlag = false;
    void Start()
    {

    }

    void Update()
    {
        if (_transitionFlag == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeScene();
            }
        }
    }

    void ChangeScene()
    {
        _transitionFlag = true;
        SceneManager.LoadScene("InGame");
    }
}