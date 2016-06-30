using UnityEngine;
using System;
using System.Collections;

public class Enemy : MonoBehaviour {
	// 現在の音声の番号(1~100)
	[SerializeField] private int voiceNum = 100;
	// オブジェクト
	private GameObject voice;
	[SerializeField] private GameObject[] playerfuda = new GameObject[25];
	[SerializeField] private GameObject[] enemyfuda = new GameObject[25];

	// 場に出てる札について
	// 0: なし
	// 1: プレイヤー札
	// 2: エネミー札
 	public int[] existFuda = new int[100];

	// Use this for initialization
	void Start () {
		voice = GameObject.Find ("Voice");
		for (int i = 0; i < 25; i++) {
			playerfuda = GameObject.FindGameObjectsWithTag ("playerfuda");
			enemyfuda = GameObject.FindGameObjectsWithTag ("enemyfuda");
			// プレイヤー札
			existFuda [ playerfuda [i].GetComponent<FudaData> ().fudanum - 1 ] = 1;
			// エネミー札
			existFuda [ enemyfuda [i].GetComponent<FudaData> ().fudanum - 1 ] = 2;
		}

	}

	// Update is called once per frame
	void Update () {
		voiceNum = voice.GetComponent<Voice> ().num;
		if (voiceNum != 100) {
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
	}

	void Level0() {
		print ("Delete VoiceNum is " + (voiceNum+1));
		// 決まり字までの時間+5.0秒後にDestroyする ここの5.0f変数にしてトップにまとめると変更簡単そう
		float delayTime = voice.GetComponent<Voice> ().voiceArray[voiceNum].preTime + 20.0f;
		print ("delayTime is " + delayTime);

		// 先にプレイヤーに取られるの前提だし、trycatch？みたいのにしたほうがいいかも
		Destroy( GameObject.Find ("Fuda" + (voiceNum+1)), delayTime );

		//existFuda [voiceNum] = 0;
	}
}
