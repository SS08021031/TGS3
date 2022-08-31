using UnityEngine;

public class Ingame_controll : MonoBehaviour
{
    public static bool ingamecontroll;

    public float time;
    void Start()
    {
        ingamecontroll = false; 
    }

    void Update()
    {
        time = Time.time;

        if (time > 5)
        {
            ingamecontroll = true;
        }
    }
}
