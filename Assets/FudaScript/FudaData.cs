using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FudaData : MonoBehaviour {

	public int fudanum = 1;
	public int kimariji;
	public int status = 0;
  public int voiceNum = 0,vn = 0;
  public GameObject voice;
	public Text target;
	public Score score;
	public otetsukiScore otetsukis;
	public float time;
	public int otetsuki = 0;
	public Enemy enemy;
	public HaichiFuda hf;
	private GameObject fudas;
	//bool cokuri = false;
	//bool pokuri = false;
	public TimeManager tm;

	void Start () {
		time = 25;
		fudas = GameObject.Find ("Fudas");
		hf = fudas.GetComponent<HaichiFuda>();
	}

	void Update () {
		if(GameObject.FindWithTag("checkbattle") != null ){

			if(time <= 0){
				voice = GameObject.Find ("Voice");
				vn = voice.GetComponent<Voice> ().num;
				enemy = voice.GetComponent<Enemy>();
				if(GameObject.FindWithTag("bb") != null)
					time = voice.GetComponent<Voice>().voiceArray[vn].timeOut;
				//print("time=" + time);
			}
		}
		if(GameObject.FindWithTag("checkbattle") != null){
			if(GameObject.FindWithTag("checkpractice") != null ){
					target = GameObject.Find ("Score").GetComponent<Text>();
					score = target.GetComponent<Score>();
					otetsukis = GameObject.Find("otetsuki").GetComponent<otetsukiScore>();
			}
		}
		if(GameObject.FindWithTag("checkbattle") != null ){
			time -= (Time.deltaTime);
			hf.updateLp();
			//if(GameObject.FindWithTag("bb") != null )
			tm = GameObject.Find("TimeManager").GetComponent<TimeManager>();
			//if(cokuri && time < 0.5){
				//SceneManager.LoadScene("okuricom", LoadSceneMode.Additive);
				//cokuri = false;
			//}

			//if(pokuri && time < 0.5){
				//SceneManager.LoadScene("okuri", LoadSceneMode.Additive);
				//pokuri = false;
			//}
			//print(time);

		}
		//print("time="+time);
	}

	public bool checkNum(int yominum){
		if(yominum == fudanum){
			return true;
		}
		else{return false;}

	}

	public int getFudanum(){
		return fudanum;
	}


	public void deleteFuda(){
		// 札削除
		Object.Destroy(gameObject);
		//enemy.updateExistFuda(fudanum-1,0);
		// SE
		voice.GetComponent<Voice> ().soundEffect();
	}

	public void changeStatus(int st){
		this.status = st;
	}

	public int getStatus(){
		return this.status;
	}

	void OnMouseDown() {
		if(GameObject.FindWithTag("check") != null ){
			voiceNum = voice.GetComponent<Voice> ().num + 1;
			if (fudanum == voiceNum) {
				if(GameObject.FindWithTag("checkpractice") != null ){
					score.score += (int)tm.time * 10;
				}
				if(GameObject.FindWithTag("checkbattle") != null){
					if(GameObject.FindWithTag("bb") !=null){
						if(this.tag == "enemyfuda"){

							tm.pokuri = true;
							//SceneManager.LoadScene("okuri", LoadSceneMode.Additive);
						}
					}
				}
				deleteFuda();
			}
			if(GameObject.FindWithTag("checkpractice") != null ){
				if (fudanum != voiceNum){
					otetsukis.otetsuki++;
				}
			}
			if(GameObject.FindWithTag("bb") != null){
				if(enemy.existFuda[fudanum-1] != enemy.existFuda[vn]){
					if(GameObject.FindWithTag("checkokuri") == null && GameObject.FindWithTag("checknarabekae") == null){
						tm.cokuri = true;
						print("お手付き");
						//SceneManager.LoadScene("okuricom", LoadSceneMode.Additive);
					}
				}
			}


		}


		if(GameObject.FindWithTag("checkokuri") != null && GameObject.FindWithTag("checknarabekae") == null){
			//Time.timeScale = 0;
			this.tag = ("enemyfuda");
			//int i,j;
			Vector3 pos;
			pos.x = 8;
			pos.y = 0;
			pos.z = -1;
			//hf.lp[(int)gameObject.transform.localPosition.z,(int)gameObject.transform.localPosition.x] = 0;
			gameObject.transform.localPosition = pos;
			gameObject.transform.rotation = Quaternion.Euler(0,0,0);
			hf.updateFudapos(fudanum-1,pos.x,pos.z);
			//enemy.updateExistFuda(fudanum-1,2);
			//for(i = 0;i < 7;i++){
				//for(j = 0; j < 17; j++){
					//print("lp["+i+","+j+"]"+hf.lp[i,j]);
				//}
			//}
			if(hf.checkLp()){
				hf.reHaichi(getFudanum());
				Time.timeScale = 1;
				SceneManager.UnloadScene("okuri");
			}
		}
	}




}
