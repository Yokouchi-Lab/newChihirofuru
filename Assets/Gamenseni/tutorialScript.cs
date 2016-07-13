using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class tutorialScript : MonoBehaviour {

	public bool pra,bat;

	public void SetPra(){
		pra = true; bat = !pra;
		CanvasSc.SetActive("practiceText",pra);
		CanvasSc.SetActive("battleText",bat);
	}

	public void SetBat(){
		pra = false; bat = !pra;
		CanvasSc.SetActive("practiceText",pra);
		CanvasSc.SetActive("battleText",bat);
	}


	public void SceneTitleLoad(){
		SceneManager.LoadScene("title");
	}

	public void SceneModeLoad(){
		SceneManager.LoadScene("mode");
	}
}
