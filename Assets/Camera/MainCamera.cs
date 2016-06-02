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

	void Start () {
		// カメラ切り替え用
		mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
		subCamera  = GameObject.Find("Sub Camera").GetComponent<Camera>();
		subCamera.enabled = false;
		// メインカメラを初期向き(角度)に
		x = initialx;
		y = initialy;
		transform.rotation = Quaternion.Euler(x,y,0);
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
		}

		// カメラを初期位置に移動
		if (Input.GetKeyDown (KeyCode.D)) {
			x = initialx;
			y = initialy;
			transform.rotation = Quaternion.Euler (initialx, initialy, 0);
		}
	}
}