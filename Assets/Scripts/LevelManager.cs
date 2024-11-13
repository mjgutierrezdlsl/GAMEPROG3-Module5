using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    public void LoadScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadScenesAdditive(string[] scenesToLoad, string[] scenesToUnload)
    {
        StartCoroutine(LoadScenes(scenesToLoad, scenesToUnload));
    }

    private IEnumerator LoadScenes(string[] scenesToLoad, string[] scenesToUnload)
    {
        List<AsyncOperation> loadOperations = new();
        foreach (var scene in scenesToLoad)
        {
            loadOperations.Add(SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive));
        }

        foreach (var loadOp in loadOperations)
        {
            while (!loadOp.isDone)
            {
                yield return null;
            }
        }

        foreach (var scene in scenesToUnload)
        {
            SceneManager.UnloadSceneAsync(scene);
        }
    }
}