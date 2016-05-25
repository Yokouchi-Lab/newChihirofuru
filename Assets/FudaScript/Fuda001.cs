using UnityEngine;
using System.Collections;

public class Fuda001 : MonoBehaviour {
	public int fudanum = 1;
	public int kimariji;
	public int status;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

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
		Object.Destroy(gameObject);
	}


}
