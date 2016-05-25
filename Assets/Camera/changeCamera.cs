using UnityEngine;
using System.Collections;

public class changeCamera : MonoBehaviour {
	Camera mainCamera;
	Camera subCamera;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
		subCamera  = GameObject.Find("Sub Camera").GetComponent<Camera>();

		subCamera.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if(mainCamera.enabled) {
				mainCamera.enabled = false;
				subCamera.enabled = true;
			} else {
				mainCamera.enabled = true;
				subCamera.enabled = false;
			}
		}
	}
}