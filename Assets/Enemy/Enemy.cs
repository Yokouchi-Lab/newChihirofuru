using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {
	// 現在の音声の番号(1~100)
	[SerializeField] private int voiceNum = 100;
	// オブジェクト
	private GameObject voice;
	//private bool flag = false;
	[SerializeField] private GameObject[] playerfuda = new GameObject[25];
	[SerializeField] private GameObject[] enemyfuda = new GameObject[25];
	private bool check;
	[SerializeField] private int vn = -1;




	// 場に出てる札について
	// 0: なし
	// 1: プレイヤー札
	// 2: エネミー札
 	public int[] existFuda = new int[100];

	// Use this for initialization
	void Start () {
		voice = GameObject.Find ("Voice");
		playerfuda = GameObject.FindGameObjectsWithTag ("playerfuda");
		enemyfuda = GameObject.FindGameObjectsWithTag ("enemyfuda");
		for (int i = 0; i < 25; i++) {
			// プレイヤー札
			existFuda [ playerfuda [i].GetComponent<FudaData> ().fudanum - 1 ] = 1;
			// エネミー札
			existFuda [ enemyfuda [i].GetComponent<FudaData> ().fudanum - 1 ] = 2;
		}

	}

	// Update is called once per frame
	/*void Update () {
		voiceNum = voice.GetComponent<Voice> ().num;
		if (voiceNum > -1 && voiceNum < 100) {
			if (existFuda [voiceNum] != 0) {
				// とりあえずオブジェクト消すだけ
				// ここで別のメソッドとかに飛ばすとよいのでは
				//targetFudaNum = fuda [voiceNum].GetComponent<FudaData> ().fudanum;
				//Destroy (fuda [voiceNum]);
				// ******************************

				if(GameObject.Find("Fuda"+(voiceNum+1))==null)
					existFuda[voiceNum] = 0;
				Level0 ();
				// ******************************
			}
		}
	}*/
	void Update () {
		// 現在のvoiceNumを取得
		voiceNum = voice.GetComponent<Voice> ().num;
		// voiceNumが0~99か？
		if (voiceNum > -1 && voiceNum < 100) {
			// voiceNumに対応する札は場に出ているか？
			if (existFuda[voiceNum] != 0 && check == false) {
				print ("Target FudaNum is " + (voiceNum+1));	// 	確認用
				// このタイミングでのvoiceNumを保存
				vn = voiceNum;
				// voiceが流れている間、一度だけInvokeするように
				check = true;
				// 札が読み終わる時間後にGetFudaメソッド起動
				Invoke ("getFuda", voice.GetComponent<Voice> ().voiceArray[voiceNum].timeOut);
			}
		}
	}

	/*void Level0() {
		if(!flag){
			print ("Delete VoiceNum is " + (voiceNum+1));
			flag = true;
		}
		// 決まり字までの時間+5.0秒後にDestroyする ここの5.0f変数にしてトップにまとめると変更簡単そう
		float delayTime = voice.GetComponent<Voice> ().voiceArray[voiceNum].preTime + 4.0f;
		//print ("delayTime is " + delayTime);

		// 先にプレイヤーに取られるの前提だし、trycatch？みたいのにしたほうがいいかも
		Destroy( GameObject.Find ("Fuda" + (voiceNum+1)), delayTime );
		SceneManager.LoadScene("okuricom", LoadSceneMode.Additive);

		//existFuda [voiceNum] = 0;
	}*/
	void getFuda () {
		Destroy( GameObject.Find ("Fuda" + (vn+1)) );
		if(GameObject.Find ("Fuda" + (vn+1)).tag == "playerfuda"){
			SceneManager.LoadScene("okuricom", LoadSceneMode.Additive);
		}

		// SEをランダムに選出して流す
		//audioSourceSE.PlayOneShot( se[UnityEngine.Random.Range(0, 4)] );
		// 後処理
		existFuda [vn] = 0;
		check = false;
	}
}
