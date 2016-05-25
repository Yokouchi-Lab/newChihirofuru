using UnityEngine;
using System.Collections;

public class FindTag : MonoBehaviour {
	public GameObject [] fuda;//札全部
	public GameObject [] usefuda;//使うやつ
	public GameObject [] playerfuda;//自陣の札
	public GameObject [] enemyfuda;//敵陣の札
	// Use this for initialization
	void Start () {
		int i;
		int j = 0;;
		int  [] random = new int[101];
		fuda = GameObject.FindGameObjectsWithTag("Fuda");
		usefuda = GameObject.FindGameObjectsWithTag("Fuda");
		playerfuda = GameObject.FindGameObjectsWithTag("Fuda");
		enemyfuda = GameObject.FindGameObjectsWithTag("Fuda");
		for(i = 0; i < fuda.Length;i++){
			 random[i] = i;
		}
		for(i = fuda.Length - 1 ; i > 2; i--){
			int p = Random.Range(1,fuda.Length);
			int t = random[i-1];
			random[i-1] = random[p];
			random[p] = t;
		}//randomにランダムセット

		for(i = 0; i < 50; i++){
			usefuda[i] = fuda[random[i]];

			print(fuda[i].name);
		}//確認用だよ

		Vector3 pos;
		pos.x = -5;
		pos.y = 0;
		pos.z = 0;

		for(i = 50; i < 99; i++){
			fuda[random[i]].transform.localPosition = pos;
		}


		Vector3 test;
		test.x = -7;
		test.y = 0;
		test.z = 1;

		fuda[random[99]].transform.localPosition = test;
		print(fuda[random[99]].name);
		//fuda[random[99]].SendMessage("deleteFuda");



		for(i = 0; i < 25; i++){
			playerfuda[i] = usefuda[i];
		}
		for(i = 25; i < 50; i++){
			enemyfuda[j] = usefuda[i];
			j++;
		}

		for(i = 0; i < 25;i++){
		//	print("playerfuda "+playerfuda[i].name);
		}//自陣札確認用

		for(i = 0; i < 25;i++){
		//	print("enemyfuda "+enemyfuda[i].name);
		}//敵陣札確認用

		Vector3 pos1;
		pos1.x = 0;
		pos1.y = 0;
		pos1.z = 0;

		for(i = 0; i < 25; i++){
			playerfuda[i].transform.localPosition = pos1;
			pos1.x += 1;
			if(i == 10 || i == 18){
				pos1.z += 1;
				pos1.x = 0;
			}
		}

		Vector3 pos2;
		pos2.x = 0;
		pos2.y = 0;
		pos2.z = -2;

		for(i = 0; i < 25; i++){
			enemyfuda[i].transform.localPosition = pos2;
			enemyfuda[i].transform.rotation = Quaternion.Euler(0,180,0);
			pos2.x += 1;
			if(i == 10 || i == 18){
				pos2.z -= 1;
				pos2.x = 0;
			}
		}


	}

	// Update is called once per frame
	void Update () {

	}
}
