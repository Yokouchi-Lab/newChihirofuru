using UnityEngine;


public class test : MonoBehaviour {
	private Transform [] fuda;//札全部
	public Transform [] usefuda = new Transform [51];//使うやつ
	public Transform [] playerfuda = new Transform [26];//自陣の札
	public Transform [] enemyfuda = new Transform [26];//敵陣の札


	// Use this for initialization
	void Start () {
		int i;
		int j = 1;
		int  [] random = new int[101];
		fuda = transform.GetComponentsInChildren<Transform>();
		usefuda = transform.GetComponentsInChildren<Transform>();
		playerfuda = transform.GetComponentsInChildren<Transform>();
		enemyfuda = transform.GetComponentsInChildren<Transform>(); //初期化

		for(i = 0; i < fuda.Length;i++){
			 random[i] = i;
		}
		for(i = fuda.Length - 1 ; i > 2; i--){
			int p = Random.Range(1,fuda.Length);
			int t = random[i-1];
			random[i-1] = random[p];
			random[p] = t;
		}//randomにランダムセット
		//for(i = 1; i < fuda.Length;i++){
			//print(fuda[random[i]].name);
		//}
		//print(fuda.Length);
		for(i = 0; i < 51; i++){
			usefuda[i] = fuda[random[i]];

			//print(fuda[random[i]].name);
		}


		for(i = 1; i < 26; i++){
			playerfuda[i] = usefuda[i];
		}
		for(i = 26; i < 51; i++){
			enemyfuda[j] = usefuda[i];
			j++;
		}

		for(i = 1; i < 26;i++){
			print("playerfuda "+playerfuda[i].name);
		}//自陣札確認用

		for(i = 1; i < 26;i++){
			print("enemyfuda "+enemyfuda[i].name);
		}//敵陣札確認用

	  Vector3 pos1;
		pos1.x = 0;
		pos1.y = 0;
		pos1.z = 0;

		for(i = 1; i < 26; i++){
			playerfuda[i].localPosition = pos1;
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

		for(i = 1; i < 26; i++){
			enemyfuda[i].localPosition = pos2;
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
