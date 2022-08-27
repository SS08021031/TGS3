using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray_test01 : MonoBehaviour
{
    public GameObject Gray;

    public LayerMask whatGround;
    void Update()
    {
        Vector3 location = Vector3.zero;
        Vector3 origin = (Gray.transform.position);
        Vector3 direction = new Vector3(0, -1, 0);
        Ray ray = new Ray(origin, direction);
        Debug.DrawRay(ray.origin, ray.direction * 1f, Color.red);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit,whatGround))
        {
            
            
            Debug.Log(hit.point);
            
            location = hit.point;
            
        }
        
    }
}
