using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class battleScript : MonoBehaviour {
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
