using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class haichibtoankib : MonoBehaviour {
	public void SceneAnkibLoad()
	{
		// Application.LoadLevelAdditive("FudaBattle");
		 SceneManager.LoadScene("ankib", LoadSceneMode.Additive);
	}

}
