using UnityEngine;
using System.Collections;

public class music : MonoBehaviour {
    public static bool up = false, pause = false;
    private AudioSource ASbgm;
    public AudioClip bgm = new AudioClip();
    private GameObject target;
    void OnLevelWasLoaded(){
        if (GameObject.Find("Plane") != null){
            Destroy(target.gameObject);
            up = false;
        }
        if(GameObject.Find("toggleList") != null){
            ASbgm.Pause();
            pause = true;
        }
        if (GameObject.Find("modeSelect") != null){
            if (pause){
                ASbgm.UnPause();
                pause = false;
            }
        }
        if (GameObject.Find("checktitle") != null){
            if (pause){
                ASbgm.UnPause();
                pause = false;
            }
        }
    }
    void Start () {
        if (!up){
            target = GameObject.Find("bgm");
            ASbgm = GetComponent<AudioSource>();
            ASbgm.clip = bgm;
            ASbgm.loop = true;
            ASbgm.Play();
            DontDestroyOnLoad(target.gameObject);
            up = true;
        }
        else
            Destroy(this.gameObject);
    }
}
