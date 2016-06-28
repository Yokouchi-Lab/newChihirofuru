using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class battleScript : MonoBehaviour {

    public void hardLoad()
    {
        SceneManager.LoadScene("haichib");
    }

    public void normalLoad()
    {
        SceneManager.LoadScene("haichib");
    }

    public void easylLoad()
    {
        SceneManager.LoadScene("haichib");
    }

    public void SeceneModeLoad()
    {
        SceneManager.LoadScene("mode");
    }
}
