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
	private AudioSource ASvoice;
    private AudioSource ASse;
	public voices[] voiceArray = new voices[100];
	public AudioClip joka = new AudioClip();
	int[] rdmArray = new int[100]; //乱数
	public int num = -1;
	private int i, j = 0;
	private bool up = false, pauseFrag = false;
	private float timeOut82 = 25.0f;
	private float timeElapsed;
	// SE用********************************************
	public AudioClip[] se = new AudioClip[4];
	[SerializeField] private bool seOnceCheck = false;
	// ************************************************

	void Start(){
        if (battleScript.enemyLevel != 3){
            for (i = 0; i < rdmArray.Length; i++)
                rdmArray[i] = i;
            int tmp = 0, random = 0;
            for (i = 0; i < rdmArray.Length; i++)
            {
                random = Random.Range(0, 100);
                tmp = rdmArray[i];
                rdmArray[i] = rdmArray[random];
                rdmArray[random] = tmp;
            }
        }
        //for (i = 0; i < rdmArray.Length; i++)
            //Debug.Log(rdmArray[i]);
        AudioSource[] audioSources = GetComponents<AudioSource>();
        ASvoice = audioSources[0];
        ASse = audioSources[1];
		ASvoice.clip = joka;
		ASvoice.Play();

		// SE用********************************************
		seOnceCheck = false;
		// ************************************************
	}

	void Update(){
		if(!pauseFrag)
			timeElapsed += Time.deltaTime;
		if (Input.GetKeyDown(KeyCode.P))
			pause();
		if(!up){
			if(timeElapsed >= timeOut82){
				num = rdmArray[j];
                ASvoice.clip = voiceArray[num].voice;
                ASvoice.Play();
				j++;
				up = !up;
				timeElapsed = 0.0f;
				//Debug.Log(voiceArray[num].voice);
				//Debug.Log(voiceArray[num].preTime);
				//Debug.Log(voiceArray[num].postTime);
			}
		}
		else{
			if (timeElapsed >= voiceArray[num].timeOut){
				// SE用********************************************
				seOnceCheck = false;
				// ************************************************
				num = rdmArray[j];
                ASvoice.clip = voiceArray[num].voice;
                ASvoice.Play();
				j++;
				timeElapsed = 0.0f;
				//Debug.Log(voiceArray[num].voice);
				//Debug.Log(voiceArray[num].preTime);
				//Debug.Log(voiceArray[num].postTime);
			}
		}

		if(GameObject.FindWithTag("checkresult") != null){
			gameObject.SetActive(false);
		}
	}

	void pause(){
		if (!pauseFrag){
            ASvoice.Pause();
			pauseFrag = !pauseFrag;
		}
		else{
            ASvoice.UnPause();
			pauseFrag = !pauseFrag;
		}
	}

	// SE用********************************************
	public void soundEffect () {
		if (seOnceCheck == false) {
			seOnceCheck = true;
			// SEをランダムに選出して流す
			ASse.PlayOneShot( se[UnityEngine.Random.Range(0, 4)] );
		}
	}
    // ************************************************
}
