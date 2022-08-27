using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Free_destroy : MonoBehaviour
{
    public float time;
    public float time_end;

    // Update is called once per frame
    void Update()
    {
        time = 1.0f * Time.deltaTime;

        if (time >= time_end)
        {
            Destroy(this.gameObject);
        }
    }
}
