using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_test02 : MonoBehaviour
{
    public Transform target;
    public float smoothing = 0.0f;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void Update()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(
            transform.position,
            targetCamPos,
            Time.deltaTime * smoothing
        );
    }
}
