using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverAnimation : MonoBehaviour
{
    public void Play ()
    {
        GetComponent<Animator> ().SetTrigger ("Play");
    }
    public void OnEndAnimation ()
    {
        SceneManager.LoadScene ("Title");
    }
}