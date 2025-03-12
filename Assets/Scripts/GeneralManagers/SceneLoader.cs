using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int scene = 1;
    void Start()
    {
        LoadLevel(scene);
    }
    public void LoadLevel(int index)
    {
        StartCoroutine(LoadAsynchronously(index));
    }

    IEnumerator LoadAsynchronously (int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            yield return null;
        }
    }


}
