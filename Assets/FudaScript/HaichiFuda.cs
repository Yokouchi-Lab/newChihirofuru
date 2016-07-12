using UnityEngine;
using System.Collections;

public class HaichiFuda :MonoBehaviour {
	public GameObject [] fuda;//札全部
	public GameObject [] usefuda;//使うやつ
	public GameObject [] playerfuda;//自陣の札
	public GameObject [] enemyfuda;//敵陣の札
	public GameObject [] junbanfuda = new GameObject[100];
	public Vector3 [] fudapos = new Vector3[100];
	public int [,] lp = new int[7,17];
	int  [] random = new int[101];
	//bool flag = false;
	// Use this for initialization
	void Start () {
		int i;
		int j = 0;
		fuda = GameObject.FindGameObjectsWithTag("Fuda");
		usefuda = GameObject.FindGameObjectsWithTag("Fuda");
		playerfuda = GameObject.FindGameObjectsWithTag("Fuda");
		enemyfuda = GameObject.FindGameObjectsWithTag("Fuda");
		for(i = 0; i < fuda.Length;i++){
			 random[i] = i;
		}


		for(i = fuda.Length - 1 ; i > 0; i--){
			int p = Random.Range(1,fuda.Length);
			int t = random[i-1];
			random[i-1] = random[p];
			random[p] = t;
		}//randomにランダムセット

		for(i = 0; i < 100; i++){
			junbanfuda[fuda[i].GetComponent<FudaData>().fudanum - 1] = fuda[i];
		}

		//for(i = 0; i < 100; i++){
			//print(i+"="+junbanfuda[i].name);
		//}



		for(i = 0; i < 50; i++){
			usefuda[i] = fuda[random[i]];
			fudapos[random[i]] = usefuda[i].transform.localPosition;

		}

		Vector3 pos;
		pos.x = -7;
		pos.y = 0;
		pos.z = 0;

		for(i = 50; i < 100; i++){
			fuda[random[i]].transform.localPosition = pos;
			fudapos[random[i]] = fuda[random[i]].transform.localPosition;

		}
		for(i = 0; i < 25; i++){
			playerfuda[i] = usefuda[i];
			playerfuda[i].tag = "playerfuda";

		}
		for(i = 25; i < 50; i++){
			enemyfuda[j] = usefuda[i];
			enemyfuda[j].tag = "enemyfuda";
			j++;
		}

		//for(i = 0; i < 25;i++){
			//print("playerfuda "+playerfuda[i].name);
		//}//自陣札確認用

		//for(i = 0; i < 25;i++){
			//print("enemyfuda "+enemyfuda[i].name);
		//}//敵陣札確認用

		Vector3 pos1;
		pos1.x = 0;
		pos1.y = 0;
		pos1.z = 2;

		for(i = 0; i < 25; i++){//最初の敵陣配置
		enemyfuda[i].transform.localPosition = pos1;
			pos1.x += 1;
			if( i == 5){
				pos1.x += 5;
			}

			if(i == 11 || i == 19){
				pos1.z -= 1;
				pos1.x = 0;
			}

			if(i == 15){
				pos1.x += 9;
			}
			if(i == 20){
				pos1.x += 12;
			}
		}

		Vector3 pos2;
		pos2.x = 0;
		pos2.y = 0;
		pos2.z = -4;

		for(i = 0; i < 25; i++){//最初自陣配置
			playerfuda[i].transform.localPosition = pos2;
			playerfuda[i].transform.rotation = Quaternion.Euler(0,180,0);
			pos2.x += 1;
			if( i == 5){
				pos2.x += 5;
			}
			if(i == 11 || i == 19){
				pos2.z += 1;
				pos2.x = 0;
			}
			if(i == 15){
				pos2.x += 9;
			}
			if(i == 20){
				pos2.x += 12;
			}
		}
		for(i = 0; i < 50; i++){
			fudapos[random[i]] = usefuda[i].transform.localPosition;

		}

	}

	public void updateFudapos(int i,float x,float z){
		fudapos[i].x = x;
		fudapos[i].z = z;
 	}

	public void updateLp (){//lpを更新します
		int num = 0;
		int n = 0;
		int i,j;
		bool f = false;
		for(i = 0; i < 7; i++){
			for(j = 0; j < 17; j++){
				f = false;
				for(num = 0; num < 100; num++){
					if(fudapos[random[num]].x == j && fudapos[random[num]].z+(2*n)-2 == i  ){
						lp[i,j] = 1;
						f = true;
						//print(lp[i,j]);
					}

				}
				if(!f){
					lp[i,j] = 0;
				}
			}
			n++;
		}

	}

	public bool checkLp(){
		updateLp();
		int j;
		for(j = 0; j < 17; j++){
			if(lp[3,j] == 1)
				return true;
			}
			return false;
	}

	public void reHaichi(int num){
		updateLp();
		int i,j;
		Vector3 pos = Vector3.zero;
		for(i = 0; i < 7; i++){
			for(j = 0; j < 17; j++){
				if(lp[i,j] == 0){
					pos.x = j;
					pos.z = i-(2*i)+2;
					junbanfuda[num-1].transform.localPosition = pos;
					updateFudapos(num-1,pos.x,pos.z);
					print(junbanfuda[num-1].transform.localPosition);
					lp[i,j] = 1;
					lp[3,8] = 0;
					return;
				}
			}
		}
	}




	// Update is called once per frame
	void Update () {
		//int i,l,j;
		if(GameObject.FindWithTag("checkresult") != null){
			gameObject.SetActive(false);
		}
		if(GameObject.FindWithTag("checkokuri") != null){
			//updateLp();
			//for(i = 0;i < 7;i++){
				//for(j = 0; j < 17; j++){
					//print("lp["+i+","+j+"]"+lp[i,j]);
				//}
			//}


		}

	}

}
