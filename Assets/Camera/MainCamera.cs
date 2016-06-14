using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	// カメラ切り替え用
	Camera mainCamera;
	Camera subCamera;
	// カメラの初期位置、向き(角度)
	[SerializeField] Vector3 initialPos = new Vector3(40f, 120f, -15f);
	[SerializeField] Vector3 initialRotation = new Vector3( 90f, 0f, 0f );

	// カメラの向き変更用の変数
	private Vector2 r = new Vector2( 0f, 0f );
	private Quaternion rQ;
	public Vector3 rE = Vector3.zero;

	// カメラの回転可能範囲(角度)、速度
	//[SerializeField] float limitUp = 80f;
	//[SerializeField] float limitDown = 100f;
	//[SerializeField] float limitLR = 60f;
	[SerializeField] Vector2 moveSpeed = new Vector2( 1.1f, 0.4f );
	// 拡大縮小可能範囲、速度
	[SerializeField] float wheelMax = 30f;
	[SerializeField] float wheelMin = 130f;
	[SerializeField] float wheelSpeed = 15f;


	// カメラ切り替え
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
		r.x = initialRotation.x;
		r.y = initialRotation.y;
		// メインカメラを初期位置に
		transform.position = initialPos;
	}


	void Start () {
		// カメラ切り替え用(サブ(40,90,-10)(仮))
		mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
		subCamera  = GameObject.Find("Sub Camera").GetComponent<Camera>();
		subCamera.enabled = false;
		this.DefaultCamera ();
	}


	void Update () {
		// カメラ切り替え
		if (Input.GetKeyDown (KeyCode.Space)) {
			this.ChangeCamera ();
		}

		// メインカメラ視点のとき
		if (mainCamera.enabled == true) {
			// カメラ回転
			r.x -= Input.GetAxis("Mouse Y") * moveSpeed.y;
			r.y += Input.GetAxis("Mouse X") * moveSpeed.x;
			rQ = Quaternion.AngleAxis( r.x, new Vector3(1,0,0) )
					* Quaternion.AngleAxis( r.y, new Vector3(0,1,0) );
			// オイラー角に変換して角度の制限
			rE = rQ.eulerAngles;
			//if ( rE.y < limitUp ) { rE.y = limitUp; }
			//if ( rE.y > limitDown ) { rE.y = limitDown; }
			//if ( rE.x < limitLR ) { rE.x = limitLR; }
			//　クォータニオンに再変換して角度変更
			//rQ = Quaternion.Euler (rE);
			transform.rotation = rQ;

			// マウスホイールで拡大縮小
			float fWheel = Input.GetAxis ("Mouse ScrollWheel"); 
			if (this.transform.position.y < wheelMax && fWheel >= 0 ) {
				transform.Translate ( 0, 0, -0.001f );
			}
			else if (this.transform.position.y > wheelMin && fWheel <= 0 ) {
				transform.Translate ( 0, 0, +0.001f );
			}
			else {
				transform.Translate ( 0, 0, fWheel * wheelSpeed );	// transform.Translate(z, x, y)
			}
		}

		// カメラを初期角度、位置に移動
		if (Input.GetKeyDown (KeyCode.C)) {
			this.DefaultCamera ();
		}
	}
}