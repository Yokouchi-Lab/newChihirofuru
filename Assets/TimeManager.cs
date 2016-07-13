using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour {
	public GameObject voice;
	public float time = 0;
	public int vn = 0;
	public bool pokuri = false;
	public bool cokuri = false;
	// Use this for initialization
	void Start () {

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
			pokuri = false;
		}

	}
}
