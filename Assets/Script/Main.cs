using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Start : MonoBehaviour
{
    public void EasyClick()
    {
        SceneManager.LoadScene(1);
    }

    public void HardClick()
    {
        SceneManager.LoadScene(2);
    }
}
