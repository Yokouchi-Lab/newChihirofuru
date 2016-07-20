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
	// 札を取る時間を遅らせるための変数
	float delay = 0f;
	//
	public TimeManager tm;

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

	// 知っている札
	[SerializeField] public int[] rememberFuda = new int[100];
	// n枚札確認用
	[SerializeField] private int[] maifudaP = new int[21];
	[SerializeField] private int[] maifudaE = new int[21];

	public void updateExistFuda (int fudaNum, int FudaState) {
		int targetM = GameObject.Find ("Fuda" + fudaNum).GetComponent<FudaData> ().maifudaNum;
		if (FudaState == 0) {
			if (existFuda [fudaNum] == 1) {
				maifudaP [targetM] -= 1;
			} else if (existFuda [fudaNum] == 2) {
				maifudaE [targetM] -= 1;
			}
		} else if (FudaState == 1) {
			maifudaP [targetM] += 1;
			maifudaE [targetM] -= 1;
		} else if (FudaState == 2) {
			maifudaP [targetM] -= 1;
			maifudaE [targetM] += 1;
		}

		existFuda [fudaNum] = FudaState;
	}


	void Start () {
		voice = GameObject.Find ("Voice");
		check = false;
		rememberFuda = new int[100];
		newRememberFuda ();
		maifudaP = new int[21];
		maifudaE = new int[21];

		existFuda = new int[100];
		playerfuda = GameObject.FindGameObjectsWithTag ("playerfuda");
		enemyfuda = GameObject.FindGameObjectsWithTag ("enemyfuda");
		for (int i = 0; i < 25; i++) {
			existFuda [playerfuda [i].GetComponent<FudaData> ().fudanum - 1] = 1;
			maifudaP [playerfuda [i].GetComponent<FudaData> ().maifudaNum] += 1;
			existFuda [enemyfuda [i].GetComponent<FudaData> ().fudanum - 1] = 2;
			maifudaE [enemyfuda [i].GetComponent<FudaData> ().maifudaNum] += 1;
		}
	}

	void Update () {
		voiceNum = voice.GetComponent<Voice> ().num;
		tm = GameObject.Find("TimeManager").GetComponent<TimeManager>();

		if (voiceNum > -1 && voiceNum < 100) {
			if (existFuda [voiceNum] != 0 && check == false) {
				check = true;

				vn = voiceNum;
				targetFuda = GameObject.Find ("Fuda" + (vn+1));
				print ("Target FudaNum is " + (vn+1));	// 確認用

				// 次へ
				checkLevel ();
			}
		}
	}



	// 難易度ごとに、別のメソッドへ飛ばす
	void checkLevel () {
		if (battleScript.enemyLevel == 0) {
			// 初級
			elementaryLevel ();
		} else if (battleScript.enemyLevel == 1) {
			// 中級
			intermediateLevel ();
		} else if (battleScript.enemyLevel == 2) {
			// 上級
			advancedLevel ();
		} else {
			// テスト用
			testLevel ();
		}
	}


	// 初級
	void elementaryLevel () {
		print ("This is Elementary Level.");	// 確認用

		// postTimeだけ、取るのを遅らせる
		delay += voice.GetComponent<Voice> ().voiceArray [vn].postTime;
		// 0.5~5.0のランダムな値だけ、取るのを遅らせる
		delay += UnityEngine.Random.Range (1.0f, 5.0f);

		// 次へ
		delayGetTime (delay);
	}

	// 中級
	void intermediateLevel () {
		print ("This is Intermediate Level.");	// 確認用

		//if (rememberFuda [vn] == 1) {
			// n枚札による遅延時間
		//	delay += voice.GetComponent<Voice> ().voiceArray [vn].preTime;
		//} else {
		//	// postTimeだけ、取るのを遅らせる
		//	delay += voice.GetComponent<Voice> ().voiceArray [vn].postTime;
		//	// 0.5~3.0のランダムな値だけ、取るのを遅らせる
		//	delay += UnityEngine.Random.Range (0.5f, 3.0f);
		//}
		delay += voice.GetComponent<Voice> ().voiceArray [vn].preTime;
		delay += UnityEngine.Random.Range (2.0f, 5.0f);

		// 次へ
		delayGetTime (delay);
	}

	// 上級
	void advancedLevel () {
		print ("This is Advanced Level.");	// 確認用

		// n枚札による遅延時間
		delay += checkMaifudaTime ();

		// 次へ
		delayGetTime (delay);
	}

	// テスト用
	void testLevel () {
		print ("This is Test Level.");	// 確認用

		delay += voice.GetComponent<Voice> ().voiceArray [vn].postTime;
		delay += 2.0f;

		// 次へ
		delayGetTime (delay);
	}



	// 札の位置などにより、取るのにかかる時間を考慮するメソッド
	// これもlevelによって場合分けしてもいいかもしれない
	void delayGetTime (float delayTime) {
		if (existFuda [vn] == 1) {
			delayTime += 1.5f;
		} else if (existFuda [vn] == 2) {
			delayTime += 1.0f;
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
		// 後処理
		//existFuda [vn] = 0;	deleteFuda()でやってくれるようになりました
		check = false;
		delay = 0f;
	}



	// 知っている札を決める関数
	void newRememberFuda () {
		int r;

		for(int i = 0; i < 50; i++) {
			// まだresultに含まれていない乱数が生成されるまで、乱数を生成する
			do {
				r = UnityEngine.Random.Range (0, 100);
			} while (rememberFuda [r] != 0);
			// 結果の保存
			rememberFuda[r] = 1;
		}
	}


	// n枚札による遅延時間確認
	float checkMaifudaTime () {
		int m = targetFuda.GetComponent<FudaData> ().maifudaNum;
		if (m == 0) {
			// 1枚札
			return voice.GetComponent<Voice> ().voiceArray [vn].preTime;
		} else {
			if (maifudaP [m] + maifudaE [m] == 1) {
				// 場に一枚だけ
				return 1.5f;
			} else if (maifudaP [m] + maifudaE [m] > 1) {
				if (maifudaP [m] == 0) {
					// すべて敵陣にある
					return 1.5f + UnityEngine.Random.Range (0.5f, maifudaE [m]);
				} else if (maifudaE [m] == 0) {
					// すべて自陣にある
					return 1.5f + UnityEngine.Random.Range (0.5f, maifudaP [m]);
				} else {
					if (m >= 1 && m <= 5) {
						// 2枚札
						return voice.GetComponent<Voice> ().voiceArray [vn].preTime;
					}


					return voice.GetComponent<Voice> ().voiceArray [vn].preTime;



				}
			}
		}

		print ("kimariji Error");	// 確認用
		return voice.GetComponent<Voice> ().voiceArray [vn].postTime;
	}
}
