using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class resultScore : MonoBehaviour {
public Score score;//Scoreからもらうよう
public Text target;//Scoreからもらうよう
public int point;//実際のリザルト用の数字
public Text pointScore;//表示させる数字
	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Score").GetComponent<Text>();
		score = target.GetComponent<Score>();
		pointScore.text =  score.score.ToString();
	}

	// Update is called once per frame
	void Update () {

	}
}
