using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Meiten : MonoBehaviour
{
    [SerializeField]
    private Material _fade_Meiten;

    public float FadeTime;
    void Start()
    {
        StartCoroutine(BeginTransition());
    }

    IEnumerator BeginTransition()
    {

        yield return Animate(_fade_Meiten, FadeTime);
    }

    /// <summary>
    /// time秒かけてトランジションを行う
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    /// 
    IEnumerator Animate(Material material, float time)
    {

        GetComponent<Image>().material = material;
        float current = 0;
        while (current < time)
        {
            material.SetFloat("_Alpha", current / time);
            yield return new WaitForEndOfFrame();
            current += Time.deltaTime;
        }
        material.SetFloat("_Alpha", 1);

    }
}
