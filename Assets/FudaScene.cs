using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FudaScene : MonoBehaviour {
	public void ScenePracticeLoad()
	{
		// Application.LoadLevelAdditive("FudaBattle");
		 SceneManager.LoadScene("Anki", LoadSceneMode.Additive);
	}

}
