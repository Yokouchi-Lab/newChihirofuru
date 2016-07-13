using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class okuricom : MonoBehaviour {
	public HaichiFuda hf;
	private GameObject fudas;
	private GameObject okurifuda;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		fudas = GameObject.Find ("Fudas");
		hf = fudas.GetComponent<HaichiFuda>();
		okurifuda = GameObject.FindWithTag("enemyfuda");
		Vector3 pos;
		pos.x = 8;
		pos.y = 0;
		pos.z = -1;
		//hf.lp[(int)gameObject.transform.localPosition.z,(int)gameObject.transform.localPosition.x] = 0;
		okurifuda.transform.localPosition = pos;
		okurifuda.transform.rotation = Quaternion.Euler(0,180,0);
		okurifuda.tag = "playerfuda";
		hf.updateFudapos(okurifuda.GetComponent<FudaData>().fudanum-1,100,100);
		hf.updateLp();
		SceneManager.LoadScene("narabekae", LoadSceneMode.Additive);
		//SceneManager.UnloadScene("okuricom");
	}

	// Update is called once per frame
	void Update () {

	}
}
