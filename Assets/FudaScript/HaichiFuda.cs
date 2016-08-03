using UnityEngine;
using System.Collections;

public class HaichiFuda :MonoBehaviour {
	public GameObject [] fuda = new GameObject[100];//札全部
	public GameObject [] usefuda = new GameObject[50];//使うやつ
	public GameObject [] playerfuda = new GameObject[25];//自陣の札
	public GameObject [] enemyfuda = new GameObject[25];//敵陣の札
	public GameObject [] junbanfuda = new GameObject[100];
	public Vector3 [] fudapos = new Vector3[100];
	public int [,] lp = new int[7,17];
	int  [] random = new int[101];
	//bool flag = false;
	// Use this for initialization
	void Start () {
		if(battleScript.enemyLevel == 3){
			HaichiDemo();
		}
		else {
			Haichi();
		}
	}

	void HaichiDemo(){
		int i;
		int j = 0;
		fuda = GameObject.FindGameObjectsWithTag("Fuda");
		for(i = 0; i < fuda.Length;i++){
			 random[i] = i;
		}

		for(i = 0; i < 100; i++){
			junbanfuda[fuda[i].GetComponent<FudaData>().fudanum - 1] = fuda[i];
		}

		usefuda[0] = junbanfuda[0];
		usefuda[1] = junbanfuda[90];
		usefuda[2] = junbanfuda[2];
		usefuda[3] = junbanfuda[91];
		usefuda[4] = junbanfuda[4];
		usefuda[5] = junbanfuda[5];
		usefuda[6] = junbanfuda[6];
		usefuda[7] = junbanfuda[7];
		usefuda[8] = junbanfuda[8];
		usefuda[9] = junbanfuda[9];
		usefuda[10] = junbanfuda[10];
		usefuda[11] = junbanfuda[11];
		usefuda[12] = junbanfuda[12];
		usefuda[13] = junbanfuda[13];
		usefuda[14] = junbanfuda[14];
		usefuda[15] = junbanfuda[15];
		usefuda[16] = junbanfuda[16];
		usefuda[17] = junbanfuda[17];
		usefuda[18] = junbanfuda[18];
		usefuda[19] = junbanfuda[19];
		usefuda[20] = junbanfuda[20];
		usefuda[21] = junbanfuda[21];
		usefuda[22] = junbanfuda[22];
		usefuda[23] = junbanfuda[23];
		usefuda[24] = junbanfuda[24];
		usefuda[25] = junbanfuda[25];
		usefuda[26] = junbanfuda[26];
		usefuda[27] = junbanfuda[27];
		usefuda[28] = junbanfuda[28];
		usefuda[29] = junbanfuda[29];
		usefuda[30] = junbanfuda[30];
		usefuda[31] = junbanfuda[31];
		usefuda[32] = junbanfuda[32];
		usefuda[33] = junbanfuda[33];
		usefuda[34] = junbanfuda[34];
		usefuda[35] = junbanfuda[35];
		usefuda[36] = junbanfuda[36];
		usefuda[37] = junbanfuda[37];
		usefuda[38] = junbanfuda[38];
		usefuda[39] = junbanfuda[39];
		usefuda[40] = junbanfuda[40];
		usefuda[41] = junbanfuda[41];
		usefuda[42] = junbanfuda[42];
		usefuda[43] = junbanfuda[43];
		usefuda[44] = junbanfuda[44];
		usefuda[45] = junbanfuda[45];
		usefuda[46] = junbanfuda[46];
		usefuda[47] = junbanfuda[47];
		usefuda[48] = junbanfuda[48];
		usefuda[49] = junbanfuda[3];

		Vector3 pos;
		pos.x = -7;
		pos.y = 0;
		pos.z = 0;

		for(i = 49; i < 100; i++){
			junbanfuda[i].transform.localPosition = pos;
			junbanfuda[1].transform.localPosition = pos;
			fudapos[i] = fuda[i].transform.localPosition;

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



/*
		Vector3 pos1;
		pos1.x = 10;
		pos1.y = 0;
		pos1.z = 50;

		for(i = 0; i < 25; i++){//最初の敵陣配置
			enemyfuda[i].transform.localPosition = pos1;

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
	*/




	}



	void Haichi (){
		int i;
		int j = 0;
		fuda = GameObject.FindGameObjectsWithTag("Fuda");

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

		for(i = 0; i < 50; i++){
			usefuda[i] = fuda[random[i]];
			fudapos[random[i]] = usefuda[i].transform.localPosition;
		}
		print("a");
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
			updateLp();
			//for(i = 0;i < 7;i++){
				//for(j = 0; j < 17; j++){
					//print("lp["+i+","+j+"]"+lp[i,j]);
				//}
			//}


		}

	}

}
