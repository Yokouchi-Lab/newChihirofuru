using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {
	// 現在流れている音声の番号(1~100)-1
	[SerializeField] private int voiceNum = 100;
	// Invokeを起動したときのvoiceNumの保存用
	[SerializeField] private int vn = -1;
	// 一度だけInvokeを起動するためのフラグ
	public bool check = false;
	//private bool eokuri = false;
	public TimeManager tm;

	// CPUの難易度(Level)分け
	// 0: 初級
	// 1: 中級
	// 2: 上級
	// それ以外: テスト用
	[SerializeField] public int enemyLevel = -1;

	// 札を取る時間を遅らせるための変数
	float delay = 0f;

	// オブジェクト
	private GameObject voice;
	private GameObject targetFuda;
	[SerializeField] private GameObject[] playerfuda = new GameObject[25];
	[SerializeField] private GameObject[] enemyfuda = new GameObject[25];

	// 場に出てる札について
	// 0: なし
	// 1: プレイヤー札
	// 2: エネミー札
	[SerializeField] public int[] existFuda = new int[100];


	// Use this for initialization
	void Start () {
		// Voice、SEオブジェクト取得
		voice = GameObject.Find ("Voice");
		check = false;

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
		tm = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		// voiceNumが0~99か？
		if (voiceNum > -1 && voiceNum < 100) {
			// voiceNumに対応する札は場に出ているか？

			//print(GameObject.Find("Fuda" + (vn+1)).GetComponent<FudaData>().time);
			if (existFuda [voiceNum] != 0 && check == false) {
				// voiceが流れている間、一度だけ札を取るように
				check = true;

				// このタイミングでのvoiceNumを保存
				vn = voiceNum;
				// 取る札を保存
				targetFuda = GameObject.Find ("Fuda" + (vn+1));
				print ("Target FudaNum is " + (vn+1));	// 確認用

				// 次へ
				checkLevel ();
			}
		}
		//delay = 0f;
	}



	// 難易度ごとに、別のメソッドへ飛ばす
	void checkLevel () {
		if (enemyLevel == 0) {
			// 初級
			elementaryLevel ();
		} else if (enemyLevel == 1) {
			// 中級
			intermediateLevel ();
		} else if (enemyLevel == 2) {
			// 上級
			advancedLevel ();
		} else {
			// テスト用
			testLevel ();
		}
	}


	// *************************************************************************************************************
	// 初級
	void elementaryLevel () {
		print ("This is Elementary Level.");	// 確認用
		// 0.5~5.0のランダムな値だけ、取るのを遅らせる
		delay += UnityEngine.Random.Range (0.5f, 5.0f);

		// 次へ
		delayGetTime (voice.GetComponent<Voice> ().voiceArray [vn].postTime + delay);
	}

	// 中級
	void intermediateLevel () {
		print ("This is Intermediate Level.");	// 確認用

		// 次へ
		delayGetTime (voice.GetComponent<Voice> ().voiceArray [vn].preTime + delay);
	}

	// 上級
	void advancedLevel () {
		print ("This is Advanced Level.");	// 確認用

		// 決まり字による遅延時間確認
		delay += checkKimariji ();

		// 次へ
		delayGetTime (delay);
	}
// テスト用
	void testLevel () {
		print ("This is Test Level.");	// 確認用
		delay += 2.0f;
		// 次へ
		delayGetTime (voice.GetComponent<Voice> ().voiceArray [vn].postTime + delay);
	}
	// *************************************************************************************************************


	// 札の位置などにより、取るのにかかる時間を考慮するメソッド
	// これもlevelによって場合分けしてもいいかもしれない
	void delayGetTime (float delayTime) {
		if (existFuda [vn] == 1) {
			delayTime += 1.0f;
		} else if (existFuda [vn] == 2) {
			delayTime += 0.5f;
		}
		print ("delayTime is " + delayTime);	// 確認用

		Invoke ("getFuda", delayTime);
	}

	// 札を取るメソッド
	void getFuda () {
		if(targetFuda != null){
			if(targetFuda.tag == "playerfuda"){
				tm.eokuri = true;
			}
			targetFuda.GetComponent<FudaData> ().deleteFuda();
		}
		//Destroy( GameObject.Find ("Fuda" + (vn+1)) );
		// ここ、targetFudaのメソッド起動する感じでいいんじゃないか
		// ↓のSEもそっちのメソッドに入れちゃえばいいんじゃないかな
		// そうすれば一回だけ音鳴らすようにもなるんじゃないかな
		// SE
		voice.GetComponent<Voice> ().soundEffect();
		// 後処理
		existFuda [vn] = 0;
		check = false;
		delay = 0;
	}



	// 決まり字による遅延時間確認
	float checkKimariji () {

		int kimariji = targetFuda.GetComponent<FudaData> ().kimariji;
		if (kimariji == 1) {
			return 0f;
		} else if (kimariji == 2) {

		} else if (kimariji == 2) {

		} else if (kimariji == 3) {

		} else if (kimariji == 4) {

		} else if (kimariji == 5) {
			if (voiceNum == 83) {
				if (existFuda[93] != 0) {
					// 5字決まり
				}
			} else if (voiceNum == 93) {

			}
			print ("5ji kimari Error");	// 確認用
		} else if (kimariji == 6) {

		}

		print ("kimariji Error");	// 確認用
		return 0f;}
}
