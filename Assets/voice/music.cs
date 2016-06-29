using UnityEngine;
using System.Collections;

public class music : MonoBehaviour {
    public bool DontDestroyEnabled = true;

    void Start () {
        if (DontDestroyEnabled){
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }
    }
	
	void Update () {
	
	}
}
