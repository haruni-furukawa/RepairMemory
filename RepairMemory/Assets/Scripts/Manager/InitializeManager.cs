using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // TODO 初期化処理
        SceneManager.LoadScene("Title");
    }
}