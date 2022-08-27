
using UnityEngine;

public class Title_StageController : MonoBehaviour
{
    public int Hori;
    public float RoationSpeed;
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");

        if (hori > 0)
        {
            transform.Rotate(new Vector3(0, 0, -RoationSpeed));
        }

        if(hori < 0)
        {
            transform.Rotate(new Vector3(0, 0, RoationSpeed));
        }
    }
}
