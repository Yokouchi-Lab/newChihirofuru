using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class backtobattle : MonoBehaviour {
	public void SceneBattleBack()
	{
		// Application.LoadLevelAdditive("FudaBattle");
		 gameObject.SetActive(false);
		 Time.timeScale = 1;
		 SceneManager.UnloadScene("okuricom");
		 SceneManager.UnloadScene("narabekae");
	}

	void Update(){
		if(GameObject.FindWithTag("checknarabekae") == null){
			Object.Destroy(gameObject);
		}
	}

}
