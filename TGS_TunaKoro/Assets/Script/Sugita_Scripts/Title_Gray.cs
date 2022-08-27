using UnityEngine;

public class Title_Gray : MonoBehaviour
{
    Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); 
    }

   
    void Update()
    {
        if (rigidbody.IsSleeping())
        {
            print("Sleeping");
            // ã•ûŒü‚É—Í‚ğ‰Á‚¦‚é.
           
        }
    }
}
