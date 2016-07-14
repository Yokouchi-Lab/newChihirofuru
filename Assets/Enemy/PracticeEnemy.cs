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

	// Use this for initialization
	void Start () {
		// Voiceオブジェクト取得
		voice = GameObject.Find ("Voice");

		check = false;
		// 場に出ている札取得
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

	// 札を取るメソッド
	void getFuda () {
		if(GameObject.Find ("Fuda" + (vn+1)) != null)
		GameObject.Find ("Fuda" + (vn+1)).GetComponent<FudaData> ().deleteFuda();
		// 後処理
		existFuda [vn] = 0;
		check = false;
	}
}
