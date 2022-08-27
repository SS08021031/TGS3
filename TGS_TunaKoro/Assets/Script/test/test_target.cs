using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_target : MonoBehaviour
{
	

	[SerializeField]
	[Tooltip("�Ώە�(��������)")]
	private GameObject target;

	private void Update()
	{
		// �Ώە��Ǝ������g�̍��W����x�N�g�����Z�o
		Vector3 vector3 = target.transform.position - this.transform.position;
		// �����㉺�����̉�]�͂��Ȃ��悤�ɂ�������Έȉ��̂悤�ɂ���B
		// vector3.y = 0f;

		// Quaternion(��]�l)���擾
		Quaternion quaternion = Quaternion.LookRotation(vector3);
		// �Z�o������]�l�����̃Q�[���I�u�W�F�N�g��rotation�ɑ��
		this.transform.rotation = quaternion;
	}
}
