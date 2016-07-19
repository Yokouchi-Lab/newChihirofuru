using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class toggleOnOf : MonoBehaviour {
	 public static int pageNum = 0;
	Toggle tog;

	public void backBut(){
		Debug.Log("back:"+pageNum);
		if(pageNum == 0){//0ページ目なら何もしない
		}else{
			//0ページ目に戻るなら序歌も出す
			if(pageNum == 1) Panel.SetActive("T" + 0,true);
			for(int i = pageNum*20+1; i <= pageNum*20+20; i++){
				Panel.SetActive("T" + i,false);
				Panel.SetActive("T" + (i-20),true);
			}
			pageNum--;
		}
	}

	public void nextBut(){
		Debug.Log("next:"+pageNum);
		if(pageNum == 4){//4ページ目なら何もしない
		}else{
			//現在0ページ目なら序歌も消す
			if(pageNum == 0) Panel.SetActive("T" + 0,false);
			for(int i = pageNum*20+1; i <= pageNum*20+20; i++){
				Panel.SetActive("T" + i,false);
				Panel.SetActive("T" + (i+20),true);
			}
			pageNum++;
		}
	}

}
