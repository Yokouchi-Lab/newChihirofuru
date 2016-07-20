using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class okuriText : MonoBehaviour {
	public GameObject text;

	// Use this for initialization
	void Start () {
		text = GameObject.Find("ot");
	}

	// Update is called once per frame
	void Update () {
		if(GameObject.FindWithTag("checkokuricom") != null){
			text.SetActive(false);
		}
		if(GameObject.FindWithTag("checkokuricom") == null){
			text.SetActive(true);
		}

	}
}
