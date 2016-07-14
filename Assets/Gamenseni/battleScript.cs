using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class battleScript : MonoBehaviour {
	// CPUの難易度(Level)分け
	// 0: 初級
	// 1: 中級
	// 2: 上級
	public static int enemyLevel = -1;

    public void hardLoad()
	{
		enemyLevel = 2;
        SceneManager.LoadScene("haichib");
    }

    public void normalLoad()
	{
		enemyLevel = 1;
        SceneManager.LoadScene("haichib");
    }

    public void easylLoad()
	{
		enemyLevel = 0;
        SceneManager.LoadScene("haichib");
    }

    public void SeceneModeLoad()
    {
        SceneManager.LoadScene("mode");
    }
}
