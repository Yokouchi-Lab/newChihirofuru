using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	// カメラ切り替え用
	Camera mainCamera;
	Camera subCamera;
	// カメラの初期位置
	[SerializeField] Vector3 initialPos = new Vector3(40f, 120f, -15f);
	// カメラの初期向き(角度)
	[SerializeField] Vector3 initialRotation = new Vector3( 90f, 0f, 0f );
	// カメラの向き変更用の変数
	float x = 0f;
	float y = 0f;
	Quaternion rQ;
	Vector3 rE = Vector3.zero;

	// カメラの回転可能範囲(角度)
	[SerializeField] float limitUp = 80f;
	[SerializeField] float limitDown = 100f;
	[SerializeField] float limitLR = 20f;
	// カメラの回転速度
	[SerializeField] float speedX = 1.1f;
	[SerializeField] float speedY = 0.4f;

	// 拡大縮小速度、範囲(1:2くらいだと通り越したりしない？)
	[SerializeField] float wheelSpeed = 15f;
	[SerializeField] float wheelMax = 30f;
	[SerializeField] float wheelMin = 130f;


	// カメラ視点切り替え
	void ChangeCamera () {
		if(mainCamera.enabled) {
			mainCamera.enabled = false;
			subCamera.enabled = true;
		} else {
			mainCamera.enabled = true;
			subCamera.enabled = false;
		}
	}

	// カメラを初期角度、位置に移動
	void DefaultCamera () {
		// メインカメラを初期向き(角度)に
		transform.eulerAngles = initialRotation;
		x = initialRotation.x;
		y = initialRotation.y;
		// メインカメラを初期位置に
		transform.position = initialPos;
	}


	void Start () {
		// カメラ切り替え用(サブ(55,100,-20)(仮))
		mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
		subCamera  = GameObject.Find("Haichi Camera").GetComponent<Camera>();
		subCamera.enabled = false;
		this.DefaultCamera ();
	}


	void Update () {
		// カメラ視点切り替え
		if (Input.GetKeyDown (KeyCode.Space)) {
			this.ChangeCamera ();
		}

		// メインカメラ視点のとき
		if (mainCamera.enabled == true) {
			// カメラ回転
			x -= Input.GetAxis("Mouse Y") * speedY;
			y += Input.GetAxis("Mouse X") * speedX;
			rQ = Quaternion.AngleAxis( x, new Vector3(1,0,0) )
				 * Quaternion.AngleAxis( y, new Vector3(0,1,0) );
			//rE = rQ.eulerAngles;
			//if ( rE.x < limitUp ) { 	//上
			//	rE.x = limitUp;
			//}
			//if ( rE.x > limitDown ) { 	//下
			//	rE.x = limitDown;
			//}
			//if ( rE.y > limitLR && rE.y < 360f-limitLR ) { 	//左右
			//	rE.y = limitLR;
			//}
			//rQ = Quaternion.Euler(rE);
			transform.rotation = rQ;

			// マウスホイールで拡大縮小
			float fWheel = Input.GetAxis ("Mouse ScrollWheel"); 
			if (transform.position.y < wheelMax && fWheel >= 0 ) {
				transform.Translate (0, 0, -0.001f);
			}
			else if (transform.position.y > wheelMin && fWheel <= 0 ) {
				transform.Translate (0, 0, +0.001f);
			}
			else {
				transform.Translate ( 0, 0, fWheel * wheelSpeed );
			}
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			this.DefaultCamera ();
		}
	}
}