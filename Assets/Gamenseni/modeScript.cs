using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class modeScript : MonoBehaviour
{

    public void ScenePracticeLoad(){
        battleScript.enemyLevel = 0;
        SceneManager.LoadScene("haichi");
    }

    public void SceneBattleLoad()
    {
        SceneManager.LoadScene("level");
    }

    public void SceneStudyLoad(){
      Debug.Log("pageNum set");
      toggleOnOf.pageNum = 0;
      SceneManager.LoadScene("study");
    }

    public void SceneTitleLoad()
    {
      Time.timeScale = 1;
        SceneManager.LoadScene("title");
    }
}
