using UnityEngine;
using System.Collections;

//********** 開始 **********//
using UnityEngine.UI;
//********** 終了 **********//

public class Score : MonoBehaviour {

//********** 開始 **********//
	public Text scoreText; //Text用変数
	public int score = 0; //スコア計算用変数
//********** 終了 **********//

	void Start (){
//********** 開始 **********//
		scoreText.text = "得点: 0"; //初期スコアを代入して画面に表示
		//Cursor.visible = false;
//********** 終了 **********//
	}

	void Update (){
		if(GameObject.FindWithTag("resultcheck") != null){
			Object.Destroy(gameObject);
		}
		scoreText.text = "得点:" + score;
	}
}
