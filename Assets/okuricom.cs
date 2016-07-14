using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class okuricom : MonoBehaviour {
	public HaichiFuda hf;
	private GameObject fudas;
	private GameObject okurifuda,okurifuda2;
	private Enemy ene;
	public TimeManager tm;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		ene = GameObject.Find("Voice").GetComponent<Enemy>();
		hf = GameObject.Find ("Fudas").GetComponent<HaichiFuda>();
		tm = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		if(tm.eokuri){
			okurifuda = GameObject.FindWithTag("enemyfuda");
			Vector3 pos;
			pos.x = 8;
			pos.y = 0;
			pos.z = -1;
			//hf.lp[(int)gameObject.transform.localPosition.z,(int)gameObject.transform.localPosition.x] = 0;
			okurifuda.transform.localPosition = pos;
			okurifuda.transform.rotation = Quaternion.Euler(0,180,0);
			okurifuda.tag = "playerfuda";
			//ene.updateExistFuda(okurifuda.GetComponent<Fudadata>().fudanum-1,1);
			hf.updateFudapos(okurifuda.GetComponent<FudaData>().fudanum-1,100,100);
			hf.updateLp();
			SceneManager.LoadScene("narabekae", LoadSceneMode.Additive);
		}

		if(tm.cokuri){

			okurifuda2 = GameObject.FindWithTag("enemyfuda");
			Vector3 pos2;
			pos2.x = 9;
			pos2.y = 0;
			pos2.z = -1;
			//hf.lp[(int)gameObject.transform.localPosition.z,(int)gameObject.transform.localPosition.x] = 0;
			okurifuda2.transform.localPosition = pos2;
			okurifuda2.transform.rotation = Quaternion.Euler(0,180,0);
			okurifuda2.tag = "playerfuda";
			//ene.updateExistFuda(okurifuda.GetComponent<Fudadata>().fudanum-1,1);
			hf.updateFudapos(okurifuda2.GetComponent<FudaData>().fudanum-1,100,100);
			hf.updateLp();
			SceneManager.LoadScene("narabekae", LoadSceneMode.Additive);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
