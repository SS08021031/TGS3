using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_test01 : MonoBehaviour
{
	// �W�����v����́i������̗́j���`
	[SerializeField] public float jumpForce = 50.0f;

	[SerializeField] public float xForce = 10.0f;

	[SerializeField] public float zForce = 10.0f;
	/// <summary>
	/// Collider�����̃g���K�[�ɓ��������ɌĂяo�����
	/// </summary>
	/// <param name="other">������������̃I�u�W�F�N�g</param>
	private void OnTriggerEnter(Collider other)
	{
		// ������������̃^�O��Player�������ꍇ
		if (other.gameObject.CompareTag("Player"))
		{
			Audio_Manager.instance.PlaySE(9);

			// �������������Rigidbody�R���|�[�l���g���擾���āA������̗͂�������
			other.gameObject.GetComponent<Rigidbody>().AddForce(xForce, jumpForce, zForce, ForceMode.Impulse);
		}
	}
}
