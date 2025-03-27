using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int scene;
    [SerializeField] float seconds;
    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex + 1;
        LoadLevel(scene);
    }
    public void LoadLevel(int index)
    {
        StartCoroutine(LoadAsynchronously(index));
    }

    IEnumerator LoadAsynchronously (int index)
    {
        yield return new WaitForSeconds(seconds);
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            yield return null;
        }
    }


}
