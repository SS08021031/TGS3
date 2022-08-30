using UnityEngine;

public class Title_Stage_Controller3D : MonoBehaviour
{
    public float Hori;
    public float RoationSpeed;
    void Update()
    {
        Hori = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.L))
        {
            Hori = 1;
        }
        else if (Input.GetKey(KeyCode.J))
        {
            Hori = -1;
        }

        if (Hori > 0)
        {
            transform.Rotate(new Vector3(0, -RoationSpeed, 0));
        }

        if (Hori < 0)
        {
            transform.Rotate(new Vector3(0, RoationSpeed, 0));
        }
    }
}
