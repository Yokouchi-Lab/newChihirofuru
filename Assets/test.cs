using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	[SerializeField] private int fudaNum = 0;
	[SerializeField] private int voiceNum = 0;
	[SerializeField] public GameObject voice;

	void Start () {
		voice = GameObject.Find ("Voice");
		//yuka = GameObject.Find ("Plane");
	}


	void Update () {

	}

	void OnMouseDown() {
		if(GameObject.FindWithTag("check") != null ){


		}

	}
}
