using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class modeScript : MonoBehaviour
{

    public void ScenePracticeLoad()
    {
        SceneManager.LoadScene("haichi");
    }

    public void SceneBattleLoad()
    {
        SceneManager.LoadScene("level");
    }

    public void SceneStudyLoad(){
      SceneManager.LoadScene("study");
    }

    public void SceneTitleLoad()
    {
        SceneManager.LoadScene("title");
    }
}
