using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    public static Golem instance;

    public GameObject crystal;
    //�N���X�^���I�u�W�F�N�g���i�[

    Vector3 target;
    //Vector3�̖��O

    public float speed = 3.0f;
    //��X���C���������X�s�[�h

    public bool isBind;

    public GameObject Line;

    public GameObject GolemImpact;
    public GameObject BindImpact;

    public GameObject BindRing;
    public GameObject targetObject;



    [SerializeField]
    [Tooltip("�Ώە�(��������)")]
    private GameObject crystal_target;
    private GameObject parentObject;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        isBind = false;
        Line.GetComponent<line_bind>().LineHide();
        targetObject = GameObject.Find("Crystal_Point");
        parentObject = GameObject.Find("Whole");
    }
    void Update()
    {
        if (isBind == false)
        {
            new Vector3(transform.position.x, transform.position.y, transform.position.z);
            //�N���X�^���̈ʒu�֌�����

            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }

        this.transform.LookAt(targetObject.transform);

        if (isBind == true)
        {

            BindRing.SetActive(true);
        }

    }
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("line"))
        {
            if (isBind == false)
            {
                Audio_Manager.instance.PlaySE(12);
                Audio_Manager.instance.PlaySE(4);
                Destroy(this.gameObject);
                var child = Instantiate(GolemImpact, transform.position, Quaternion.identity);
                child.transform.parent = parentObject.transform;
                //�X�R�A���オ��
                score_test.instance.score += 500;
                //Debug.Log("line");

                //Debug.Log("line");
            }


        }
        if (other.CompareTag("crystal"))
        {
            if (isBind == false)
            {
                Audio_Manager.instance.PlaySE(1);
                Destroy(this.gameObject);

                //�X�R�A������
                score_test.instance.score -= 200;

                //Debug.Log("line");
            }
        }


        //if (other.CompareTag("Player"))
        //{
          //  Audio_Manager.instance.PlaySE(10);
          //  isBind = true;

           // Line.GetComponent<line_bind>().LineActive();

        //}
    }
    public void Bind_Destroy(GameObject gameObject)
    {
        if (isBind == true)
        {
            Audio_Manager.instance.PlaySE(11);
            Debug.Log("kieru");
            Destroy(this.gameObject);
            //�X�R�A���オ��
            score_test.instance.score += 500;
            Instantiate(BindImpact, transform.position, Quaternion.identity);
        }
    }
}
