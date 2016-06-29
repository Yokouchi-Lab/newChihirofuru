using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FudaScene3 : MonoBehaviour {
	public void ScenescoreResultLoad()
	{
		// Application.LoadLevelAdditive("FudaBattle");
		 gameObject.SetActive(false);
		 SceneManager.LoadScene("scoreResult", LoadSceneMode.Additive);
	}

}
