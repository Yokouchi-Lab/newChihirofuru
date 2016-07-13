using UnityEngine;
using System.Collections;

public class studyPlayer : MonoBehaviour
{
    private studyVoice player;
    private getToggle listner;
    private int num = -1;
    // Use this for initialization
    void Start()
    {
        GameObject refvoice = GameObject.Find("studyAS");
        GameObject refnum = GameObject.Find("group");
        player = refvoice.GetComponent<studyVoice>();
        listner = refnum.GetComponent<getToggle>();
    }

    void play(){
        num = listner.getNum();
        player.play(num);
    }

    void pause(){
        player.pause();
    }

    void stop(){
        player.stop();
    }
}
