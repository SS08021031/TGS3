using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Sugita : MonoBehaviour
{
    public GameObject player;

    //�v���C���[�Ƃ̋����𒲐�����ϐ�
    public float offsetx;
    public float offsety;
    public float offsetz;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //�v���C���[�̃|�W�V����
        Vector3 pos = player.transform.position;

        //�J�����̃|�W�V����
        transform.position = new Vector3(pos.x + offsetx, pos.y + offsety, pos.z + offsetz);
    }
}
