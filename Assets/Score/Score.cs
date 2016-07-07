using UnityEngine;
using System.Collections;

//********** 開始 **********//
using UnityEngine.UI;
//********** 終了 **********//

public class Score : MonoBehaviour {

//********** 開始 **********//
	public Text scoreText;//score用Text
	//public Text otetsukiText; //お手付き回数用Text
	public int score = 0; //スコア計算用変数
	//public int otetsuki = 0; //お手付き用変数
//********** 終了 **********//

	void Start (){
//********** 開始 **********//
		scoreText.text = "得点: 0"; //初期スコアを代入して画面に表示
		//otetsukiText.text = "お手付き: 0回"
//********** 終了 **********//
	}

	void Update (){
		if(GameObject.FindWithTag("checkresult") != null){
			Object.Destroy(gameObject);
		}
		scoreText.text = "得点:" + score;
	}
}
