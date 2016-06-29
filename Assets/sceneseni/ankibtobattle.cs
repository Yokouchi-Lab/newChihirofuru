using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ankibtobattle : MonoBehaviour {
	public void ScenePracticeLoad()
	{
		// Application.LoadLevelAdditive("FudaBattle");
		 gameObject.SetActive(false);
		 SceneManager.LoadScene("battle", LoadSceneMode.Additive);
	}

	void Update(){
		if(GameObject.FindWithTag("checkbattle") != null){
			Object.Destroy(gameObject);
		}
	}

}
