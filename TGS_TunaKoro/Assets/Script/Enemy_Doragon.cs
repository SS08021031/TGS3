using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Doragon : MonoBehaviour
{
    public float moveSpeed;    //�G�l�~�[�̓����X�s�[�h
    public float speedMod = 1f;

    private Path thePath;      //�G�l�~�[�̈ړ�����o�H
    private int currentPoint;  //���݂�PathPoint��
    private bool rechedEnd;    //�ړI�n�ɕt�������ǂ���

    public float attacksTime, damagePerAttck; //�U���ƍU���̊Ԃ̎��ԁA�^����_���[�W�̐�
    private float attackCount;  

    private Crystal_Test TheCrystal;�@//�G�l�~�[�̖ړI�n

    public int selectedAttackpoint; //����������U������ꏊ

    public GameObject targetObject;

    public GameObject projectile; //���˂���e
    public Transform firePoint;   //���˂���ꏊ
    public float shotTime = 1f;   //���ˊԊu
    private float shotCounter;  //0�ɂȂ�ƒe�𔭎˂���

    public float totalHP; //�G�l�~�[��HP
    public bool dead ;  //�h���S���̌��j�𔻒�
    public float deadcount;//�h���S�������܂ł̎���
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

            //�G�l�~�[�����ݒn����thePath�܂œ���
            transform.position = Vector3.MoveTowards(transform.position, thePath.point[currentPoint].position, moveSpeed * Time.deltaTime);

            //�G�l�~�[���ړI�n(PathPoint01)�ɓ��������玟�̖ړI�n(PathPoint02)�Ɍ�����
            if (Vector3.Distance(transform.position, thePath.point[currentPoint].position) < .01f)
            {
                //���̖ړI�n�͍����ǂ蒅����Path�Ɂ{1����Path
                currentPoint = currentPoint + 1;
                if (currentPoint >= thePath.point.Length)
                {
                    rechedEnd = true;
                    //����Path�������Ȃ����Ƃ�Castle��AttackPoint�̒����烉���_���Ɍ�����
                    selectedAttackpoint = Random.Range(0, TheCrystal.AttackPoints.Length);
                }
            }
        }
        else
        {
            this.transform.LookAt(targetObject.transform);
            //�G�l�~�[�����ݒn����AttackPoint�܂œ���
            
            transform.position = Vector3.MoveTowards(transform.position, TheCrystal.AttackPoints[selectedAttackpoint].position, moveSpeed * Time.deltaTime);
            
            //�e�𔭎˂��鏈��
            shotCounter -= Time.deltaTime;

            if (shotCounter <= 0)
            {
                shotCounter = shotTime;              
                Instantiate(projectile, firePoint.position, firePoint.rotation);
            }       
        }

        //HP��0�ɂȂ����Ƃ��̏���
        if (totalHP <= 0)
        {
            //���j�G�t�F�N�g�J�n
            dead = true;
            //����SE����
            //Audio_Manager.instance.PlaySE(1);
            //�G�l�~�[����
            //Destroy(gameObject);
        }
        if (dead == true)
        {
            deadcount = deadcount + 1.0f * Time.deltaTime;
            //������~
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