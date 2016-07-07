using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class resultotetsuki : MonoBehaviour {
public otetsukiScore otetsukis;
public Text targeto;
public Text pointOtetsuki;
	// Use this for initialization
	void Start () {
		targeto = GameObject.Find ("otetsuki").GetComponent<Text>();
		otetsukis = targeto.GetComponent<otetsukiScore>();
		pointOtetsuki.text = otetsukis.otetsuki.ToString();
	}

	// Update is called once per frame
	void Update () {

	}
}
