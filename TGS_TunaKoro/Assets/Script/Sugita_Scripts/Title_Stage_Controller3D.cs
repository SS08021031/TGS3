using UnityEngine;

public class Title_Stage_Controller3D : MonoBehaviour
{
    public int Hori;
    public float RoationSpeed;
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");

        if (hori > 0)
        {
            transform.Rotate(new Vector3(0, -RoationSpeed, 0));
        }

        if (hori < 0)
        {
            transform.Rotate(new Vector3(0, RoationSpeed, 0));
        }
    }
}
