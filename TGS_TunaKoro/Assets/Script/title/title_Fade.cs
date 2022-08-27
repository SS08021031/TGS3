using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title_Fade : MonoBehaviour
{
    [SerializeField]
    string targetSceneName = "Scene 02";
    [SerializeField]
    GameObject transitionPrefab;
    readonly float waitTime = 0.5f;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(nameof(LoadScene));
        }
    }
    IEnumerator LoadScene()
    {
        Instantiate(transitionPrefab);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(targetSceneName);
    }
}
