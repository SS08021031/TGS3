using UnityEngine;

public class Ingame_controll : MonoBehaviour
{
    public static Ingame_controll instance;
    public bool ingamecontroll;
    public float time;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        ingamecontroll = false;
        time = 0.0f;
    }

    void Update()
    {
        if (time < 5.0f)
        {
            time += Time.deltaTime;
            ingamecontroll = false;
        }
        else
        {
            ingamecontroll = true;
        }
    }
}
