using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timerb : MonoBehaviour {

public Text text;
public float time = 20;
int flag = 0;

// Use this for initialization
void Start () {

	text.text = ((int)time).ToString();

}

// Update is called once per frame
void Update () {
	if(time < 0 && flag == 0){
		gameObject.SetActive(false);
		SceneManager.LoadScene("practice", LoadSceneMode.Additive);
		flag = 1;
	}

	if(GameObject.FindWithTag("checkbattle") != null){
		gameObject.SetActive(false);
	}
	time -= (Time.deltaTime);
	text.text = ((int)time).ToString ();

	}
}
