using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_test8 : MonoBehaviour
{
    public Transform target;
    public float smoothing = 0.0f;
    private Vector3 offset;
    //public float rotationSpeed = 60.0f;
    [SerializeField]
    float angularSpeed = 1f;
    public float inputX;
    //public float inputY;
    public float speedX;
    public float speedY;

    /// <summary>
    /// �v���C���[�I�u�W�F�N�g
    /// </summary>
    [SerializeField] GameObject Player;
    /// <summary>
    /// (����)�N���X�^���I�u�W�F�N�g
    /// </summary>
    [SerializeField] GameObject Crystal;

    /// <summary>
    /// �J��������v���C���[�Ƃ̋���-�㉺
    /// </summary>
    [SerializeField] float cameraUp;
    /// <summary>
    /// �J��������v���C���[�Ƃ̋���-�O��
    /// </summary>
    [SerializeField] float cameraDistance;
    /// <summary>
    /// �O��X�����̃J���������p�i0.0�`1.0�j
    /// </summary>
    [SerializeField] float y; 
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(
            transform.position,
            targetCamPos,
            Time.deltaTime * smoothing
        );

        // �J�������W�ϐ��i�v���C���[���W�����j
        Vector3 cameraPos = Player.transform.position;
        // �O��X�����̊p�x�����i�X�����c���ł���悤�Ɂj
        cameraPos = new Vector3(cameraPos.x, cameraPos.y * y, cameraPos.z);

        // �v���C���[���N���X�^���̕����x�N�g��
        Vector3 ToCrystalVector = (Crystal.transform.position - Player.transform.position).normalized;
        // ���̃x�N�g���̋t�����ɃJ�������W��z�u
        cameraPos -= ToCrystalVector * cameraDistance;
        // �J��������ɂ��炷
        cameraPos += new Vector3(0, cameraUp, 0);

        // �J������position�ɍ��W�ϐ�����
        //transform.position = cameraPos;

        // �J�����̕������N���X�^���֌�������
        transform.LookAt(Crystal.transform);

        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            //this.transform.Rotate();
            gameObject.transform.rotation = Quaternion.identity;
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            this.transform.Rotate(0.0f, -180.0f, 0.0f);
        }

        if (Input.GetKeyUp(KeyCode.Joystick1Button5))
        {
            this.transform.Rotate(0.0f, 180.0f, 0.0f);
        }

        // ���Ɏ��_�ړ�
        if (Input.GetKey(KeyCode.J) || inputX == -1)
        {
            this.transform.Rotate(0.0f, speedX * Time.deltaTime, 0.0f);
        }
        // �E�Ɏ��_�ړ�
        if (Input.GetKey(KeyCode.L) || inputX == 1)
        {
            this.transform.Rotate(0.0f, speedX * -1.0f * Time.deltaTime, 0.0f);
        }
        // ��Ɏ��_�ړ�
        //if (Input.GetKey(KeyCode.K) || inputY == 1)
        {
            //this.transform.Rotate(0.0f, 0.0f, Time.deltaTime * speedY);
        }
        // ���Ɏ��_�ړ�
        //if (Input.GetKey(KeyCode.I) || inputY == -1)
        {
            //this.transform.Rotate(0.0f, 0.0f, Time.deltaTime * -1.0f * speedY);
        }

        //float rotation = inputX * rotationSpeed;
        //rotation *= Time.deltaTime;
        //transform.Rotate(0, rotation, 0);

        //�R���g���[���[����
        if (Input.GetAxisRaw("Vertical2") < 0)
        {
            inputX = -1;
        }
        else if (0 < Input.GetAxisRaw("Vertical2"))
        {
            inputX = 1;
        }
        else
        {
            inputX = 0;
        }

        if (Input.GetAxisRaw("Horizontal2") < 0)
        {
           // inputY = -1;
        }
        else if (0 < Input.GetAxisRaw("Horizontal2"))
        {
           // inputY = 1;
        }
        else
        {
            //inputY = 0;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
