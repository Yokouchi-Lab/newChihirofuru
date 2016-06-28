using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	// 現在の音声の番号(1~100)
	[SerializeField] private int voiceNum = 0;
	// 取ろうとしている札の番号(1~100)_確認用
	//[SerializeField] private int fudaNum = -1;
	// オブジェクト
	private GameObject voice;
	//[SerializeField] private GameObject[] fuda = new GameObject[100];
	[SerializeField] private GameObject[] playerfuda = new GameObject[25];
	[SerializeField] private GameObject[] enemyfuda = new GameObject[25];

	// 場に出てる札について（役に立つだろうかこれ）
	// 0: なし
	// 1: プレイヤー札
	// 2: エネミー札
	[SerializeField] private int[] existFuda = new int[101];	// 最初(voiceNumが0ののとき)の場合も入れて、
	// 他のと違って番号-1じゃなくて番号そのまま指定
	// Use this for initialization
	void Start () {
		voice = GameObject.Find ("Voice");

		//int playerFudaNum, enemyFudaNum;
		for (int i = 0; i < 25; i++) {
			playerfuda = GameObject.FindGameObjectsWithTag ("playerfuda");
			enemyfuda = GameObject.FindGameObjectsWithTag ("enemyfuda");
			// プレイヤー札
			//playerFudaNum = playerfuda [i].GetComponent<FudaData> ().fudanum;
			//fuda [playerFudaNum-1] = playerfuda [i];
			existFuda [ playerfuda [i].GetComponent<FudaData> ().fudanum ] = 1;
			// エネミー札
			//enemyFudaNum = enemyfuda [i].GetComponent<FudaData> ().fudanum;
			//fuda [enemyFudaNum-1] = enemyfuda [i];
			existFuda [ enemyfuda [i].GetComponent<FudaData> ().fudanum ] = 2;
		}

	}

	// Update is called once per frame
	void Update () {
		voiceNum = voice.GetComponent<Voice> ().num;
		if (existFuda [voiceNum] != 0) {	// ここexistFuda[]にしてるけどfuda[]のnullとの比較でもいけます？
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
		Debug.LogWarning ("Delate VoiceNum is " + voiceNum);
		// 決まり字までの時間+1.5秒後に実行する ここの1.5f変数にしてトップにまとめると変更簡単そう
		float delayTime = voice.GetComponent<Voice> ().voiceArray[voiceNum-1].preTime + 1.5f;
		Debug.LogWarning ("delayTime is " + delayTime);

		Destroy( GameObject.Find ("Fuda" + voiceNum) );

		//fuda [voiceNum - 1] = null;
		existFuda [voiceNum] = 0;
	}
}
