﻿using UnityEngine;
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
	public float time;

	void Start () {
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

					target = GameObject.Find ("Score").GetComponent<Text>();
					score = target.GetComponent<Score>();

		}
		if(GameObject.FindWithTag("checkbattle") != null ){
			time -= (Time.deltaTime);
		}
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
				// とりあえずオブジェクト消すだけ
				score.score += (int)time * 10;
				print("time="+time);
				print("score="+score.score);
				deleteFuda();
			}


		}
	}




}
