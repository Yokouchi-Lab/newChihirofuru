using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class titleScript : MonoBehaviour {
	
	public void SceneModeLoad () {
        SceneManager.LoadScene("mode");
	}

    public void quit()
    {
        Application.Quit();
    }
}
