using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class battleManager : MonoBehaviour {



		// Use this for initialization
		void Start () {
		}

		// Update is called once per frame
		void Update () {
			if(GameObject.FindWithTag("playerfuda") == null){
				//print("player win!!");

				SceneManager.LoadScene("battleresult");
			}
			else if(GameObject.FindWithTag("enemyfuda") == null){
				//print("CPU win!!");
				SceneManager.LoadScene("battlelose");
			}
		}
	}
