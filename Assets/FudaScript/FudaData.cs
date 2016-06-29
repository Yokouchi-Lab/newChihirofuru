using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FudaData : MonoBehaviour {

	public int fudanum = 1;
	public int kimariji;
	public int status = 0;
  public int voiceNum = 0,vn = 0;
  public GameObject voice;
	public Text target;
	public Score score;
	public otetsukiScore otetsukis;
	public float time;
	public int otetsuki = 0;
	private GameObject[] playerfuda = new GameObject[25];
	private GameObject[] enemyfuda = new GameObject[25];
	public int[] existFuda = new int[100];

	void Start () {
		time = 25;
		for(int i = 0; i <100; i++){
			existFuda[i] = 0;
		}
		for (int i = 0; i < 25; i++) {
			playerfuda = GameObject.FindGameObjectsWithTag ("playerfuda");
			enemyfuda = GameObject.FindGameObjectsWithTag ("enemyfuda");
			// プレイヤー札
			existFuda [ playerfuda [i].GetComponent<FudaData> ().fudanum - 1 ] = 1;
			print("aaa" + playerfuda [i].GetComponent<FudaData> ().fudanum);
			// エネミー札
			existFuda [ enemyfuda [i].GetComponent<FudaData> ().fudanum - 1 ] = 2;
		}

	}

	void Update () {
		if(GameObject.FindWithTag("checkbattle") != null ){

			if(time <= 0){

				voice = GameObject.Find ("Voice");
				vn = voice.GetComponent<Voice> ().num;
				time = voice.GetComponent<Voice>().voiceArray[vn].timeOut;
				//print("time=" + time);
			}
		}
		if(GameObject.FindWithTag("checkbattle") != null){
			if(GameObject.FindWithTag("checkpractice") != null ){
					target = GameObject.Find ("Score").GetComponent<Text>();
					score = target.GetComponent<Score>();
					otetsukis = GameObject.Find("otetsuki").GetComponent<otetsukiScore>();
			}
		}
		if(GameObject.FindWithTag("checkbattle") != null ){
			time -= (Time.deltaTime);
		}
		//print("time="+time);
	}

	public bool checkNum(int yominum){
		if(yominum == fudanum){
			return true;
		}
		else{return false;}

	}

	public int getFudanum(){
		return fudanum;
	}


	public void deleteFuda(){
		Object.Destroy(gameObject);
	}

	public void changeStatus(int st){
		this.status = st;
	}

	public int getStatus(){
		return this.status;
	}

	void OnMouseDown() {
		if(GameObject.FindWithTag("check") != null ){
			voiceNum = voice.GetComponent<Voice> ().num + 1;
			if (fudanum == voiceNum) {
				if(GameObject.FindWithTag("checkpractice") != null ){
					score.score += (int)time * 10;
				}
				deleteFuda();
			}
			if(GameObject.FindWithTag("checkpractice") != null ){
				if (fudanum != voiceNum){
					otetsukis.otetsuki++;
				}
			}

			if(existFuda[fudanum-1] != existFuda[voiceNum-1]){
				print("お手付き");
			}


		}
	}




}
