using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TrainingManager : MonoBehaviour {
public GameObject fudas;
public GameObject [] usefuda = new GameObject[50];
	// Use this for initialization
	void Start () {
		fudas = GameObject.Find("Fudas");
		for(int i = 0; i < 50; i++){
			this.usefuda[i] = fudas.GetComponent<HaichiFuda>().usefuda[i];
		}


	}

	// Update is called once per frame
	void Update () {
		for(int i = 0; i < 50; i++){
			if(usefuda[i] != null){
				return;
			}
		}
		if(GameObject.FindWithTag("resultcheck") == null){
			SceneManager.LoadScene("scoreResult", LoadSceneMode.Additive);
		}
	}
}
