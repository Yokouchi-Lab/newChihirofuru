using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FudaScene2 : MonoBehaviour {
	public void ScenePracticeLoad()
	{
		// Application.LoadLevelAdditive("FudaBattle");
		 gameObject.SetActive(false);
		 SceneManager.LoadScene("practice", LoadSceneMode.Additive);
	}

	void Update(){
		if(GameObject.FindWithTag("checkbattle") != null){
			Object.Destroy(gameObject);
		}
	}

}
