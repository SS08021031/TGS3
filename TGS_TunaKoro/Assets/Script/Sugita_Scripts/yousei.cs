using UnityEngine;

public class yousei : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �O�Ɉړ�����
        transform.position += transform.right * speed * Time.deltaTime;
    }
}

