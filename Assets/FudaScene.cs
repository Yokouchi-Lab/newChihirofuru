using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FudaScene : MonoBehaviour {
	public void ScenePracticeLoad()
	{
		 gameObject.SetActive(false);
		 SceneManager.LoadScene("anki", LoadSceneMode.Additive);
	}

}
