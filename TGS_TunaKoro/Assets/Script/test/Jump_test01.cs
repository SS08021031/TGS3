using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_test01 : MonoBehaviour
{
	// ジャンプする力（上向きの力）を定義
	[SerializeField] public float jumpForce = 50.0f;

	[SerializeField] public float xForce = 10.0f;

	[SerializeField] public float zForce = 10.0f;
	/// <summary>
	/// Colliderが他のトリガーに入った時に呼び出される
	/// </summary>
	/// <param name="other">当たった相手のオブジェクト</param>
	private void OnTriggerEnter(Collider other)
	{
		// 当たった相手のタグがPlayerだった場合
		if (other.gameObject.CompareTag("Player"))
		{
			Audio_Manager.instance.PlaySE(9);

			// 当たった相手のRigidbodyコンポーネントを取得して、上向きの力を加える
			other.gameObject.GetComponent<Rigidbody>().AddForce(xForce, jumpForce, zForce, ForceMode.Impulse);
		}
	}
}
