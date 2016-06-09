using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour{
    AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;

    void Start(){
        int rdm = Random.Range(0, 2);
        if (rdm == 0)
            audioClip = audioClip1;
        else if (rdm == 1)
            audioClip = audioClip2;
        else
            audioClip = audioClip3;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.A) == true){
            // Torigger
            Debug.Log("A!");
            audioSource.Play();
        }
    }
}