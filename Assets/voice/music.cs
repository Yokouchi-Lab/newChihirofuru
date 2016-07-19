using UnityEngine;
using System.Collections;

public class music : MonoBehaviour {
    public static bool up = false, mute = false;
    private AudioSource ASbgm;
    public AudioClip bgm = new AudioClip();
    private GameObject target;
    void OnLevelWasLoaded(){
        if (GameObject.Find("Plane") != null){
            Destroy(target.gameObject);
            up = false;
        }
        if(GameObject.Find("toggleList") != null){
            ASbgm.mute = true;
            mute = true;
        }
        if (GameObject.Find("modeSelect") != null){
            if (mute){
                ASbgm.mute = false;
                mute = false;
            }
        }
        if (GameObject.Find("checktitle") != null){
            if (mute){
                ASbgm.mute = false;
                mute = false;
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
