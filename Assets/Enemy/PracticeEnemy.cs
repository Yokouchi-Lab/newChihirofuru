using UnityEngine;
using System;
using System.Collections;

public class PracticeEnemy : MonoBehaviour {
	// SE
	AudioSource audioSourceSE;
	public AudioClip[] se = new AudioClip[4];

	// 現在の音声の番号(1~100)-1
	[SerializeField] private int voiceNum = 100;
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
		// AudioSource取得
		audioSourceSE = gameObject.GetComponent<AudioSource>();
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
				// 札が読み終わる時間後にDestroy
				Invoke ("getFuda", voice.GetComponent<Voice> ().voiceArray[voiceNum].timeOut);
				// voiceが流れている間、一度だけInvokeするように
				check = true;
			}
		}
	}

	// 札を取るメソッド
	void getFuda () {
		Destroy( GameObject.Find ("Fuda" + (voiceNum+1)) );
		// SEをランダムに選出して流す
		audioSourceSE.PlayOneShot( se[UnityEngine.Random.Range(0, 4)] );
		// 後処理
		existFuda [voiceNum] = 0;
		check = false;
	}
}
