using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClearAnimation : MonoBehaviour
{
    public void OnEndAnimation ()
    {
        SceneManager.LoadScene ("Title");
    }
}