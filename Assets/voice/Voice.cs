using UnityEngine;
using System.Collections;

public class Voice : MonoBehaviour {
	AudioSource audioSource;
	public AudioClip[] voiceArray = new AudioClip[100]; //VoiceData
	public AudioClip joka = new AudioClip();
	int[] rdmArray = new int[100]; //乱数
	int num = 0, j = 0;
	public float timeOut = 25;
	private float timeElapsed;

	void Start(){
			for (int i = 0; i < rdmArray.Length; i++)
					rdmArray[i] = i;
			int tmp = 0;
			int random = Random.Range(0,100);
			for (int i = 0; i < rdmArray.Length; i++){
					tmp = rdmArray[i];
					rdmArray[i] = rdmArray[random];
					rdmArray[random] = tmp;
			}
			audioSource = gameObject.GetComponent<AudioSource>();
			audioSource.clip = joka;
			audioSource.Play();
	}

	void Update(){
			timeElapsed += Time.deltaTime;
			if (timeElapsed >= timeOut){
					num = rdmArray[j];
					audioSource.clip = voiceArray[num];
					audioSource.Play();
					j++;
					timeElapsed = 0.0f;
			}
	}
}
