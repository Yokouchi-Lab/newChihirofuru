using UnityEngine;
using System.Collections;

[System.Serializable]
public class voices{
    public AudioClip voice;
    public float preTime;
    public float postTime;
    public float timeOut;
}

public class Voice : MonoBehaviour {
    AudioSource audioSource;
    public voices[] voiceArray = new voices[100];
    public AudioClip joka = new AudioClip();
    int[] rdmArray = new int[100]; //乱数
    public int num = 0;
    private int i, j = 0, up = 0;
    private float timeOut82 = 25.0f;
    private float timeElapsed;

    void Start(){
        for (i = 0; i < rdmArray.Length; i++)
            rdmArray[i] = i;
        int tmp = 0, random = 0;
        for (i = 0; i < rdmArray.Length; i++){
            random = Random.Range(0, 100);
            tmp = rdmArray[i];
            rdmArray[i] = rdmArray[random];
            rdmArray[random] = tmp;
        }
        for (i = 0; i < rdmArray.Length; i++)
            //Debug.Log(rdmArray[i]);
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = joka;
        audioSource.Play();
    }

    void Update(){
        timeElapsed += Time.deltaTime;
        if(up == 0){
            if(timeElapsed >= voiceArray[num].timeOut){
                num = rdmArray[j];
                audioSource.clip = voiceArray[num].voice;
                audioSource.Play();
                j++;
                up = 1;
                timeElapsed = 0.0f;
                //Debug.Log(voiceArray[num].voice);
                //Debug.Log(voiceArray[num].preTime);
                //Debug.Log(voiceArray[num].postTime);
            }
        }
        else{
            if (timeElapsed >= voiceArray[num].timeOut){
                num = rdmArray[j];
                audioSource.clip = voiceArray[num].voice;
                audioSource.Play();
                j++;
                timeElapsed = 0.0f;
                //Debug.Log(voiceArray[num].voice);
                //Debug.Log(voiceArray[num].preTime);
                //Debug.Log(voiceArray[num].postTime);
            }
        }

        if(GameObject.FindWithTag("resultcheck") != null){
          gameObject.SetActive(false);
        }
    }
}
