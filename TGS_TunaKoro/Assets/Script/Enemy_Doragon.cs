using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Doragon : MonoBehaviour
{
    public float moveSpeed;    //エネミーの動くスピード
    public float speedMod = 1f;

    private Path thePath;      //エネミーの移動する経路
    private int currentPoint;  //現在のPathPoint数
    private bool rechedEnd;    //目的地に付いたかどうか

    public float attacksTime, damagePerAttck; //攻撃と攻撃の間の時間、与えるダメージの数
    private float attackCount;  

    private Crystal_Test TheCrystal;　//エネミーの目的地

    public int selectedAttackpoint; //到着したら攻撃する場所

    public GameObject targetObject;

    public GameObject projectile; //発射する弾
    public Transform firePoint;   //発射する場所
    public float shotTime = 1f;   //発射間隔
    private float shotCounter;  //0になると弾を発射する

    public float totalHP; //エネミーのHP
    public bool dead ;  //ドラゴンの撃破を判定
    public float deadcount;//ドラゴン爆発までの時間
    public GameObject explosion_ef;
    public GameObject explosion_doragon;
    GameObject obj;
    GameObject explosion;

    void Start()
    {
        if (thePath == null)
        {
            thePath = FindObjectOfType<Path>();
        }

        if (TheCrystal == null)
        {
            TheCrystal = FindObjectOfType<Crystal_Test>();
        }

        dead = false;
        deadcount = 0.0f;
        explosion = GameObject.Find("Explosion");

        attackCount = attacksTime;

        targetObject = GameObject.Find("AttackPoint");
        
    }

    //
    void Update()
    {
        
        
        if (rechedEnd == false)
        {
            transform.LookAt(thePath.point[currentPoint]);

            //エネミーが現在地からthePathまで動く
            transform.position = Vector3.MoveTowards(transform.position, thePath.point[currentPoint].position, moveSpeed * Time.deltaTime);

            //エネミーが目的地(PathPoint01)に到着したら次の目的地(PathPoint02)に向かう
            if (Vector3.Distance(transform.position, thePath.point[currentPoint].position) < .01f)
            {
                //次の目的地は今たどり着いたPathに＋1したPath
                currentPoint = currentPoint + 1;
                if (currentPoint >= thePath.point.Length)
                {
                    rechedEnd = true;
                    //次のPathが無くなったときCastleのAttackPointの中からランダムに向かう
                    selectedAttackpoint = Random.Range(0, TheCrystal.AttackPoints.Length);
                }
            }
        }
        else
        {
            this.transform.LookAt(targetObject.transform);
            //エネミーが現在地からAttackPointまで動く
            
            transform.position = Vector3.MoveTowards(transform.position, TheCrystal.AttackPoints[selectedAttackpoint].position, moveSpeed * Time.deltaTime);
            
            //弾を発射する処理
            shotCounter -= Time.deltaTime;

            if (shotCounter <= 0)
            {
                shotCounter = shotTime;              
                Instantiate(projectile, firePoint.position, firePoint.rotation);
            }       
        }

        //HPが0になったときの処理
        if (totalHP <= 0)
        {
            //撃破エフェクト開始
            dead = true;
            //消滅SE発生
            //Audio_Manager.instance.PlaySE(1);
            //エネミー消滅
            //Destroy(gameObject);
        }
        if (dead == true)
        {
            deadcount = deadcount + 1.0f * Time.deltaTime;
            //動き停止
            moveSpeed = 0.0f;

            if (deadcount >= 0.1f && deadcount <= 0.2f)
            {
                obj = (GameObject)Instantiate(explosion_ef, this.transform.position, Quaternion.identity);
                obj.transform.parent = explosion.transform;
            }
            else if(deadcount >= 3.0f)
            {
                Instantiate(explosion_doragon, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("line"))
        {
            totalHP -= 1;
            Debug.Log("Hit");
        }
    }
            //
            public void Setup(Crystal_Test newCrystal, Path newPath)
   {
       TheCrystal = newCrystal;
       thePath = newPath;
  }
}