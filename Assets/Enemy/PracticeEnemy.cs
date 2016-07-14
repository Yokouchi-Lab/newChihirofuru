using UnityEngine;
using System;
using System.Collections;

public class PracticeEnemy : MonoBehaviour {
	// 現在の音声の番号(1~100)-1
	[SerializeField] private int voiceNum = 100;
	// Invokeを起動したときのvoiceNumの保存用
	[SerializeField] private int vn = -1;

	// オブジェクト
	private GameObject voice;
	[SerializeField] private GameObject[] playerfuda = new GameObject[25];
	[SerializeField] private GameObject[] enemyfuda = new GameObject[25];


	// 場に出てる札について
	// 0: なし
	// 1: プレイヤー札
	// 2: エネミー札
	[SerializeField] public int[] existFuda = new int[100];
	private bool check;


	void Start () {
		voice = GameObject.Find ("Voice");
		check = false;

		playerfuda = GameObject.FindGameObjectsWithTag ("playerfuda");
		enemyfuda = GameObject.FindGameObjectsWithTag ("enemyfuda");
		for (int i = 0; i < 25; i++) {
			existFuda [ playerfuda [i].GetComponent<FudaData> ().fudanum - 1 ] = 1;
			existFuda [ enemyfuda [i].GetComponent<FudaData> ().fudanum - 1 ] = 2;
		}
	}

	void Update () {
		voiceNum = voice.GetComponent<Voice> ().num;

		if (voiceNum > -1 && voiceNum < 100) {
			if (existFuda[voiceNum] != 0 && check == false) {
				check = true;

				vn = voiceNum;
				print ("Target FudaNum is " + (voiceNum+1));	// 	確認用

				Invoke ("getFuda", voice.GetComponent<Voice> ().voiceArray[voiceNum].timeOut);
			}
		}
	}

	// 札を取るメソッド
	void getFuda () {
		if (GameObject.Find ("Fuda" + (vn + 1)) != null) {
			GameObject.Find ("Fuda" + (vn + 1)).GetComponent<FudaData> ().deleteFuda ();
		}
		// 後処理
		existFuda [vn] = 0;
		check = false;
	}
}
