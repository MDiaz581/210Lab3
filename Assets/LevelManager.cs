using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public void GotoLevel(int level)
    {
        Debug.Log("Loading scene " + level);
        SceneManager.LoadScene(level);
    }
}
