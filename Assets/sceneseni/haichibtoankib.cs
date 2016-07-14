using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class haichibtoankib : MonoBehaviour {
	public void SceneAnkibLoad()
	{
		// Application.LoadLevelAdditive("FudaBattle");
			gameObject.SetActive(false);
		 SceneManager.LoadScene("ankib", LoadSceneMode.Additive);
	}

}
