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
        DontDestroyOnLoad(this.gameObject);
        if (managerScenes == null)
        {
            managerScenes = this;
        }
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
                Scenes.Add(scene.path);
        }
        //int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        //string[] scenes = new string[sceneCount];
        //for (int i = 0; i < sceneCount; i++)
        //{
        //    scenes[i] = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i));
        //}
        //for (int i = 0; i < scenes.Length; i++)
        //{
        //    Scenes.Add(scenes[i]);
        //}
    }
    public void GoToSceneX(int i)
    {
        SceneManager.LoadScene(i);
    }

}
