using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class studyButton : MonoBehaviour {
	static int pageNum = 0;
	public  Toggle[] toggleArray = new Toggle[101];

	public void backBut(){
		if(pageNum == 0){//0ページ目なら何もしない
		}else{
			for(int i = pageNum*20+1; i <= pageNum*20+20; i++){
				Panel.SetActive("But" + i,false);
				Panel.SetActive("But" + (i-20),true);
			}
			pageNum--;
		}
	}

	public void nextBut(){
		if(pageNum == 4){//4ページ目なら何もしない
		}else{
			for(int i = pageNum*20+1; i <= pageNum*20+20; i++){
				Panel.SetActive("But" + i,false);
				Panel.SetActive("But" + (i+20),true);
			}
			pageNum++;
		}
	}

}
