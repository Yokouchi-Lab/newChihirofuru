using UnityEngine;
using System.Collections;

public class coliderTest : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		GameObject.Destroy(other.gameObject);
	}
}
