using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class resultScore : MonoBehaviour {
public Score score;//Scoreからもらうよう
public Text target;//Scoreからもらうよう
//public Text targeto;
public int point;//実際のリザルト用の数字
public Text pointScore;//表示させる数字
//public Text pointOtetsuki;
	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Score").GetComponent<Text>();
		//targeto = GameObject.Find ("otetsuki").GetComponent<Text>();
		score = target.GetComponent<Score>();
		//otetsukis = targeto.GetComponent<otetsukiScore>();
		point = score.score;
		pointScore.text =  score.score.ToString();
		//pointOtetsuki.text = otetsukis.otetsuki.ToString();
	}

	// Update is called once per frame
	void Update () {

	}
}
