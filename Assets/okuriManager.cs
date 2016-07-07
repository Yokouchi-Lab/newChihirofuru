using UnityEngine;
using System.Collections;

public class okuriManager : MonoBehaviour {
	public HaichiFuda hf;
	private GameObject fudas;

	// Use this for initialization
	void Start () {
		fudas = GameObject.Find ("Fudas");
		hf = fudas.GetComponent<HaichiFuda>();
	}

	// Update is called once per frame
	void Update () {

	}
}
