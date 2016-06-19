using UnityEngine;
using System.Collections;

public class FudaData : MonoBehaviour {

	public int fudanum = 1;
	public int kimariji;
	public int status = 0;
  public int voiceNum = 0;
  public GameObject voice;

	void Update () {
		if(GameObject.FindWithTag("check") != null ){
			voice = GameObject.Find ("Voice");
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
				deleteFuda();
			}


		}
	}




}
