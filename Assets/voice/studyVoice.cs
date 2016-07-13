using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class studyVoice : MonoBehaviour
{

    private AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();
    private bool pauseFrag = false;

    // Use this for initialization
    void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    public void play(int n){
        audioSource.clip = audioClip[n];
        audioSource.Play();
        pauseFrag = false;
    }

    public void pause(){
        if (!pauseFrag){
            audioSource.Pause();
            pauseFrag = !pauseFrag;
        }
        else{
            audioSource.UnPause();
            pauseFrag = !pauseFrag;
        }
    }

    public void stop(){
        audioSource.Stop();
    }
}