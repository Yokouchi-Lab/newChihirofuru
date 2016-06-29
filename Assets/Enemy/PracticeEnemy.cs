using UnityEngine;
using System;
using System.Collections;

public class PracticeEnemy : MonoBehaviour {
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
	[SerializeField] private int[] existFuda = new int[100];

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
				print ("Delete VoiceNum is " + (voiceNum+1));
				// 札が読み終わる時間語にDestroy
				Destroy( GameObject.Find ("Fuda" + (voiceNum+1)), voice.GetComponent<Voice> ().voiceArray[voiceNum].timeOut );
				existFuda [voiceNum] = 0;
			}
		}
	}
}

