using UnityEngine;
using System.Collections;

public class music : MonoBehaviour {
    private static bool up = false;
    void OnLevelWasLoaded(){
        if (GameObject.Find("Plane") != null){
            Destroy(this.gameObject);
            up = !up;
        }
    }
    void Start () {
        if (!up){
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this.gameObject);
            up = !up;
        }
        else
            Destroy(this.gameObject);
    }

        void Update () {
	
	}
}
