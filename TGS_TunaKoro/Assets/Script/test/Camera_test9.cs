using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_test9 : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�I�u�W�F�N�g
    /// </summary>
    [SerializeField] GameObject Player;
    /// <summary>
    /// (����)�N���X�^���I�u�W�F�N�g
    /// </summary>
    [SerializeField] GameObject Crystal;

    /// <summary>
    /// �J��������v���C���[�Ƃ̋���
    /// </summary>
    [SerializeField] Vector2 cameraDistance;

    /// <summary>
    /// �ő�J������]�p�x
    /// </summary>
    [SerializeField] float cameraRotate;
    /// <summary>
    /// �J������]���x
    /// </summary>
    [SerializeField] float cameraAngleSpeed;

    /// <summary>
    /// �������ő勗��
    /// </summary>
    [SerializeField] Vector2 MaxDistance;
    /// <summary>
    /// �k�߂���ŏ�����
    /// </summary>
    [SerializeField] Vector2 MinDistance;
    /// <summary>
    /// �����ϓ����x
    /// </summary>
    [SerializeField] Vector2 cameraMoveSpeed;

    private float rotate;
    private float moveX;
    private float moveY;

    private float inputX;
    private float inputY;
    void Start()
    {
        moveX = cameraDistance.x;
        moveY = cameraDistance.y;
    }


    void Update()
    {
        // �J�������W�ϐ��i�v���C���[���W�����j
        Vector3 cameraPos = Player.transform.position;

        // �E�X�e�B�b�N�㉺����ŃJ�����̋����𓮂���
        inputY = Input.GetAxis("Horizontal2");
        // float�ϐ��덷�����p
        if (inputY < 0.001f && inputY > -0.001f) inputY = 0;
        if (Input.GetKey(KeyCode.I))
        {
            inputY = 1;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            inputY = -1;
        }
        else
        {
            inputY = 0;
        }
        if (moveX <= MaxDistance.x && moveX >= MinDistance.x)
        {
            moveX += cameraMoveSpeed.x * -inputY * Time.deltaTime;
        }
        else if (moveX > MaxDistance.x) moveX = MaxDistance.x;
        else if (moveX < MinDistance.x) moveX = MinDistance.x;

        if (moveY <= MaxDistance.y && moveY >= MinDistance.y)
        {
            moveY += cameraMoveSpeed.y * -inputY * Time.deltaTime;
        }
        else if (moveY > MaxDistance.y) moveY = MaxDistance.y;
        else if (moveY < MinDistance.y) moveY = MinDistance.y;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            moveX = cameraDistance.x;
            moveY = cameraDistance.y;
        }

        // �v���C���[���N���X�^���̕����x�N�g��
        Vector3 ToCrystalVector = (Crystal.transform.position - Player.transform.position).normalized;
        // ���̃x�N�g���̋t�����ɃJ�������W��z�u
        cameraPos -= ToCrystalVector * moveX;
        // �J��������ɂ��炷
        cameraPos += new Vector3(0, moveY, 0);

        // �J������position�ɍ��W�ϐ�����
        transform.position = cameraPos;

        // �J�����̕������N���X�^���֌�������
        transform.LookAt(Crystal.transform);

        // �E�X�e�B�b�N���E����ŃJ���������E�֓�����
        inputX = Input.GetAxis("Vertical2");
        // float�ϐ��덷�����p
        if (inputX < 0.001f && inputX > -0.001f) inputX = 0;
        if (Input.GetKey(KeyCode.J))
        {
            inputX = 1;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            inputX = -1;
        }
        else
        {
            inputX = 0;
        }

        if (inputX == 0 && rotate > 1)
        {
            rotate -= cameraAngleSpeed * Time.deltaTime;
        }
        else if (inputX == 0 && rotate < -1 || inputX == 0 && Input.GetKey(KeyCode.L) && rotate < -1)
        {
            rotate += cameraAngleSpeed * Time.deltaTime;
        }
        else if (inputX == 0)
        {
            rotate = 0;
        }
        else if (rotate < cameraRotate && rotate > -cameraRotate)
        {
            rotate += cameraAngleSpeed * -inputX * Time.deltaTime;
        }
        transform.Rotate(0, rotate, 0);
    }
}
