using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class battleScript : MonoBehaviour {

    public void hardLoad()
    {
        SceneManager.LoadScene("dummyBattle");
    }

    public void normalLoad()
    {
        SceneManager.LoadScene("dummyBattle");
    }

    public void easylLoad()
    {
        SceneManager.LoadScene("dummyBattle");
    }

    public void SeceneModeLoad()
    {
        SceneManager.LoadScene("mode");
    }
}
