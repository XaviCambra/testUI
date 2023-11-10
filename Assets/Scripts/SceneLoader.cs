using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void LoadSceneAdditive(string name)
    {
        StartCoroutine(Load(name, true));
    }
    public void UnloadScene(string name)
    {
        StartCoroutine(Load(name, false));
    }

    IEnumerator Load(string name, bool load)
    {
        AsyncOperation sceneLoaded = load
            ? SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive)
            : SceneManager.UnloadSceneAsync(name);

        while (!sceneLoaded.isDone)
        {
            yield return null;
        }
        if(load)
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
    }

    public void AnimationUnloadActualScene(AnimationClip animation)
    {
        StartCoroutine(WaitLoad(SceneManager.GetActiveScene().name, false, animation.length));
    }

    IEnumerator WaitLoad(string name, bool load, float delay)
    {
        yield return new WaitForSeconds(delay);

        AsyncOperation sceneLoaded = load
            ? SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive)
            : SceneManager.UnloadSceneAsync(name);

        while (!sceneLoaded.isDone)
        {
            yield return null;
        }
    }

    public void OpenURL()
    {
        Application.OpenURL("https://github.com/XaviCambra/testUI");
    }
}
