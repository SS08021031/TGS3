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
        

        //コンポーネントを取得する
        this.line = GetComponent<LineRenderer>();

        //線の幅を決める
        this.line.startWidth = 1.5f;
        this.line.endWidth = 1.5f;

        //頂点の数を決める
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
        //Updateに書いたのは作者が動的に変化させたかったため
        //0や1は頂点の順番(多分)
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
