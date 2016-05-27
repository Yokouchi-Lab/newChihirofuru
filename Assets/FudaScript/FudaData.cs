using UnityEngine;
using System.Collections;

public class FudaData : MonoBehaviour {

	public int fudanum = 1;
	public int kimariji;
	public int status;

	public bool checkNum(int yominum){
		if(yominum == fudanum){
			return true;
		}
		else{return false;}

	}

	public int getFudanum(){
		return fudanum;
	}


	//public void deleteFuda(){
		//Object.Destroy(gameObject);
	//}

}
