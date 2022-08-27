using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_test : MonoBehaviour
{
    LineRenderer line;
    CapsuleCollider capsule;

    //GameObject Hoge;
    //GameObject Puke;

    public Transform start;
    public Transform target;

    public float LineWidth;
    private float distance;

     private List<GameObject> hitObjects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
        //this.Hoge = GameObject.Find("player");
        //this.Puke = GameObject.Find("moto");
        

        //�R���|�[�l���g���擾����
        this.line = GetComponent<LineRenderer>();

        //���̕������߂�
        this.line.startWidth = 1.5f;
        this.line.endWidth = 1.5f;

        //���_�̐������߂�
        this.line.positionCount = 2;

        capsule = gameObject.AddComponent<CapsuleCollider>();
        capsule.radius = LineWidth / 2;
        capsule.center = Vector3.zero;
        capsule.direction = 2;
        capsule.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Update�ɏ������͍̂�҂����I�ɕω�����������������
        //0��1�͒��_�̏���(����)
        line.SetPosition(0, start.transform.position);
        line.SetPosition(1, target.transform.position);

        capsule.transform.position = start.position + (target.position - start.position) / 2;
        capsule.transform.LookAt(start.position);
        capsule.height = (target.position - start.position).magnitude;
        //Mesh mesh = new Mesh();
        //line.BakeMesh(mesh, true);
        //capsule.sharedMesh = mesh;

        
        
    }

     void OnTriggerEnter(Collider col)
    {
        hitObjects.Add(col.gameObject);
        if (col.gameObject.tag == "enemy")
        {
            //Destroy(col.gameObject);
        }
    }
    
}
