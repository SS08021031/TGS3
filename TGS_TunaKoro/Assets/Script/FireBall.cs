using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;�@//�e�̃X�s�[�h

    //public GameObject impactEffect; //���e���̃G�t�F�N�g

    public float damageAmount;�@//�^����_���[�W
    private bool Damaged;

    void Start()
    {

        //�e�̑��x = ���ʂ�movespeed�̐��l
        rb.velocity = transform.forward * moveSpeed;
        //SE����
        //Audio_Manager.instance.PlaySE(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //�Փ˂����I�u�W�F�N�g�̃^�O��"Enemy"�̏ꍇ
        if (other.tag == "Enemy" && !Damaged)
        {
            //�Փ˂����I�u�W�F�N�g��"Enemy_HPControl"��"TakeDamage"�����s
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
