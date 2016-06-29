using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	// 現在の音声の番号(1~100)
	[SerializeField] private int voiceNum = 0;
	// オブジェクト
	private GameObject voice;
	[SerializeField] private GameObject[] playerfuda = new GameObject[25];
	[SerializeField] private GameObject[] enemyfuda = new GameObject[25];

	// 場に出てる札について
	// 0: なし
	// 1: プレイヤー札
	// 2: エネミー札
	// 最初(voiceNumが0ののとき)の場合も入れて、他のと違って番号-1じゃなくて番号そのまま指定
	[SerializeField] private int[] existFuda = new int[101];

	// Use this for initialization
	void Start () {
		voice = GameObject.Find ("Voice");
		for (int i = 0; i < 25; i++) {
			playerfuda = GameObject.FindGameObjectsWithTag ("playerfuda");
			enemyfuda = GameObject.FindGameObjectsWithTag ("enemyfuda");
			// プレイヤー札
			existFuda [ playerfuda [i].GetComponent<FudaData> ().fudanum ] = 1;
			// エネミー札
			existFuda [ enemyfuda [i].GetComponent<FudaData> ().fudanum ] = 2;
		}

	}

	// Update is called once per frame
	void Update () {
		voiceNum = voice.GetComponent<Voice> ().num;
		if (existFuda [voiceNum] != 0) {
			// とりあえずオブジェクト消すだけ
			// ここで別のメソッドとかに飛ばすとよいのでは
			//targetFudaNum = fuda [voiceNum-1].GetComponent<FudaData> ().fudanum;
			//Destroy (fuda [voiceNum-1]);
			// ******************************
			Level0();
			// ******************************
		}
	}

	void Level0() {
		Debug.Log ("Delete VoiceNum is " + (voiceNum));
		// 決まり字までの時間+5.0秒後に実行する ここの5.0f変数にしてトップにまとめると変更簡単そう
		float delayTime = voice.GetComponent<Voice> ().voiceArray[voiceNum-1].preTime + 5.0f;
		Debug.Log ("delayTime is " + delayTime);

		// 先にプレイヤーに取られるの前提だし、trycatch？みたいのにしたほうがいいかも
		Destroy( GameObject.Find ("Fuda" + (voiceNum)), delayTime );

		existFuda [voiceNum] = 0;
	}
}
