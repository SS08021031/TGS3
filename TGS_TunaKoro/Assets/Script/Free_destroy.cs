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
        time_end -= Time.deltaTime;

        if (time_end <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
