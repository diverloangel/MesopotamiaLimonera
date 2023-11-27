using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScenes : MonoBehaviour
{
    public static ManagerScenes managerScenes;

    public List<string> Scenes = new List<string>();

    private void Awake()
    {
        if (managerScenes == null)
        {
            managerScenes = this;
        }
    }
    public void GoToSceneX(int i)
    {
        SceneManager.LoadScene(i);
    }

}
