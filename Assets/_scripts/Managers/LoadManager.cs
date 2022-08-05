using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �������� �������� �������
/// </summary>
public class LoadManager : MonoBehaviour
{
    string layerScene = "load";
    /// <summary>
    /// ��������� ����� �����
    /// </summary>
    /// <param name="newScene">��� ����� �����</param>
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
