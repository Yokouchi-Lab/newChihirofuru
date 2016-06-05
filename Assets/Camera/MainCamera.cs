using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	// カメラ切り替え用
	Camera mainCamera;
	Camera subCamera;
	// カメラの回転速度
	[SerializeField] float speedX = 1.1f;
	[SerializeField] float speedY = 0.4f;
	// カメラの初期向き(角度)
	[SerializeField] float initialx = 90f;
	[SerializeField] float initialy = 180f;
	// 
	float x = 0f;
	float y = 0f;

	// カメラの初期位置
	[SerializeField] Vector3 initialPos = new Vector3(40f, 120, -15f);
	// 拡大縮小速度、範囲(1:2くらいだと通り越したりしない？)
	[SerializeField] float wheelSpeed = 15f;
	[SerializeField] float wheelMax = 30f;
	[SerializeField] float wheelMin = 130f;


	void Start () {
		// カメラ切り替え用(サブ(55,100,-20)(仮))
		mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
		subCamera  = GameObject.Find("Sub Camera").GetComponent<Camera>();
		subCamera.enabled = false;
		// メインカメラを初期向き(角度)に
		x = initialx;
		y = initialy;
		transform.rotation = Quaternion.Euler(x,y,0);
		// メインカメラを初期位置に
		transform.position = initialPos;
	}


	void Update () {
		// マウス位置による画面移動用
		int width = Screen.width;
		int height = Screen.height;
		Vector3 mouse = Input.mousePosition;

		// カメラ視点切り替え
		if (Input.GetKeyDown (KeyCode.Space)) {
			if(mainCamera.enabled) {
				mainCamera.enabled = false;
				subCamera.enabled = true;
			} else {
				mainCamera.enabled = true;
				subCamera.enabled = false;
			}
		}

		// メインカメラ視点のとき
		if (mainCamera.enabled == true) {
			// カメラ回転
			if (mouse.x < width / 3) {
				y -= speedX;
				transform.rotation = Quaternion.Euler (x, y, 0);
			}
			if (mouse.x > width - width / 3) {
				y += speedX;
				transform.rotation = Quaternion.Euler (x, y, 0);
			}
			if (mouse.y > height - height / 3) {
				x -= speedY;
				transform.rotation = Quaternion.Euler (x, y, 0);
			} 
			if (mouse.y < height / 3) {
				x += speedY;
				transform.rotation = Quaternion.Euler (x, y, 0);
			}

			// マウスホイールで拡大縮小
			float fWheel = Input.GetAxis ("Mouse ScrollWheel"); 
			if (transform.position.y < wheelMax && fWheel >= 0 ) {
				transform.Translate (0, 0, -0.001f);
			}
			else if (transform.position.y > wheelMin && fWheel <= 0 ) {
				transform.Translate (0, 0, +0.001f);
			}
			else {
				transform.Translate (0, 0, fWheel * wheelSpeed);
			}
		}

		// カメラを初期角度、位置に移動
		if (Input.GetKeyDown (KeyCode.D)) {
			x = initialx;
			y = initialy;
			transform.rotation = Quaternion.Euler (initialx, initialy, 0);
			transform.position = initialPos;
		}
	}
}