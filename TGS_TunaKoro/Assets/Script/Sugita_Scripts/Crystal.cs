using UnityEngine;

public class Crystal : MonoBehaviour
{
    public GameObject Crystal_Effect;

    void Start()
    {
        
    }

    void Update()
    {
        Instantiate(Crystal_Effect, transform.position, Quaternion.identity);
    }
}
