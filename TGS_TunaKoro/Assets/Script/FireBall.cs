using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;　//弾のスピード

    //public GameObject impactEffect; //着弾時のエフェクト

    public float damageAmount;　//与えるダメージ
    private bool Damaged;

    void Start()
    {

        //弾の速度 = 正面にmovespeedの数値
        rb.velocity = transform.forward * moveSpeed;
        //SE発生
        //Audio_Manager.instance.PlaySE(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //衝突したオブジェクトのタグが"Enemy"の場合
        if (other.tag == "Enemy" && !Damaged)
        {
            //衝突したオブジェクトの"Enemy_HPControl"の"TakeDamage"を実行
            //other.GetComponent<Enemy_HPControl>().TakeDamage(damageAmount);
            //Damaged = true;
        }
        Destroy(gameObject);
        //Instantiate(impactEffect, transform.position, Quaternion.identity);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
