using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class sumScore : MonoBehaviour {
	public resultScore rs;
	public resultotetsuki ro;
	public Text sump;
	public int sumpoint = 0;
	// Use this for initialization
	void Start () {
		rs = GameObject.Find("point").GetComponent<resultScore>();
		ro = GameObject.Find("pointo").GetComponent<resultotetsuki>();
		sumpoint = rs.point + (-100*ro.point);
		sump.text = sumpoint.ToString();
	}

	// Update is called once per frame
	void Update () {
		sumpoint = rs.point + (-100*ro.point);
		sump.text = sumpoint.ToString();
	}
}
