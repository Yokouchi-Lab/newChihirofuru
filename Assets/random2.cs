using UnityEngine;
using System.Collections;

public class random2 : MonoBehaviour {


	//プレハブを変数に代入
	public GameObject Fuda1;

	void Start () {


		//オブジェクトの座標
		float x = 10;//Random.Range(0.0f, 2.0f);
		float y = 0;//Random.Range(0.0f, 2.0f);
		float z = 10;//Random.Range(0.0f, 2.0f);

		//オブジェクトを生産
		transform.position = new Vector3(x, y, z);

	}

}