using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FudaScene2 : MonoBehaviour {
	public void ScenePracticeLoad()
	{
		// Application.LoadLevelAdditive("FudaBattle");
		 SceneManager.LoadScene("FudaBattle", LoadSceneMode.Additive);
	}

}
