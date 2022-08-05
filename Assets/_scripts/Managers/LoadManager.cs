using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Менеджер загрузки уровней
/// </summary>
public class LoadManager : MonoBehaviour
{
    string layerScene = "load";
    /// <summary>
    /// Загружает новую сцену
    /// </summary>
    /// <param name="newScene">Имя новой сцены</param>
    public void LoadScene(string newScene)
    {
        if (newScene != null)
        {
            SceneManager.LoadScene(layerScene, LoadSceneMode.Additive);

            StartCoroutine(AsyncLoadScene(newScene));
        }
    }

    IEnumerator AsyncLoadScene(string newScene)
    {
        yield return new WaitForSeconds(1);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(newScene);
        
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
