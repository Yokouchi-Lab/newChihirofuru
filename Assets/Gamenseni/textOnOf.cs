using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class textOnOf : MonoBehaviour {

	public int toggleNum = 0;
	Toggle _toggle;

	void Start(){
		_toggle = gameObject.GetComponent<Toggle>();
		//Debug.Log("Start:"+toggle.name);
	}

	public void OnClick(){
		//Debug.Log(toggle.name);

		if(_toggle.isOn) toggleSet.SetActive(_toggle,true); //トグルにチェックが入っていれば表示
		else toggleSet.SetActive(_toggle,false); //入っていなければ非表示に
	}
}
