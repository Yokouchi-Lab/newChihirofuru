using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class modeScript : MonoBehaviour
{

    public void ScenePracticeLoad()
    {
        SceneManager.LoadScene("Fuda");
    }

    public void SceneBattleLoad()
    {
        SceneManager.LoadScene("battle");
    }

    public void SceneTitleLoad()
    {
        SceneManager.LoadScene("title");
    }
}
