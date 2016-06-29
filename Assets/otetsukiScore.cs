using UnityEngine;
using System.Collections;

//********** 開始 **********//
using UnityEngine.UI;
//********** 終了 **********//

public class otetsukiScore : MonoBehaviour {

//********** 開始 **********//
	public Text otetsukiText; //お手付き回数用Text
	public int otetsuki = 0; //お手付き用変数
//********** 終了 **********//

	void Start (){
//********** 開始 **********//
		otetsukiText.text = "お手付き: 0回";//初期スコアを代入して画面に表示
//********** 終了 **********//
	}

	void Update (){
		if(GameObject.FindWithTag("resultcheck") != null){
			Object.Destroy(gameObject);
		}
		otetsukiText.text = "お手付き:" + otetsuki +"回";
	}
}
