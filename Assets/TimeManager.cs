using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour {
	public GameObject voice;
	public float time = 0;
	public int vn = 0;
	public bool pokuri = false;//敵陣抜いた
	public bool cokuri = false;//お手付き
	public bool eokuri = false;//CPUが自陣ぬいた
	// Use this for initialization
	void Start () {
		time = 25;
	}

	// Update is called once per frame
	void Update () {
		if(time <= 0){
			voice = GameObject.Find ("Voice");
			vn = voice.GetComponent<Voice> ().num;
			time = voice.GetComponent<Voice>().voiceArray[vn].timeOut;
		}
		time -= (Time.deltaTime);

		if(cokuri && time < 0.5){
			SceneManager.LoadScene("okuricom", LoadSceneMode.Additive);
			cokuri = false;
		}

		if(pokuri && time < 0.5){
			SceneManager.LoadScene("okuri", LoadSceneMode.Additive);
			Time.timeScale = 0;
			pokuri = false;
		}

		if(GameObject.Find ("Fuda" + (vn+1)) != null){
			//print(GameObject.Find("Fuda" + (vn+1)).GetComponent<FudaData>().time);
			if(GameObject.Find ("Fuda" + (vn+1)).tag == "playerfuda" ){
				if(time < 0.5 && eokuri == true){
					SceneManager.LoadScene("okuricom", LoadSceneMode.Additive);
					eokuri = false;
				}
			}
		}

	}
}
