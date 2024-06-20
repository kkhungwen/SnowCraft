using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : SingletonMonoBehaviour<CustomSceneManager>
{
    private SceneEnum currentScene;
    public void ChangeScene(SceneEnum toScene)
    {
        if(currentScene != toScene)
        {
            SceneManager.UnloadSceneAsync(currentScene.ToString());
            SceneManager.LoadScene(toScene.ToString(), LoadSceneMode.Additive);
        }
    }
}
