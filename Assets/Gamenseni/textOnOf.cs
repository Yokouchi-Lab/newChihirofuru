using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class textOnOf : MonoBehaviour {

	public int toggleNum = 0;
	public static int toggleNow = -1;
	Toggle _toggle;

	void Start(){
		_toggle = gameObject.GetComponent<Toggle>();
		//Debug.Log("Start:"+toggle.name);
	}

	public void OnClick(){
		Debug.Log(_toggle.name);

		if(_toggle.isOn){
				toggleSet.SetActive(_toggle,true); //トグルにチェックが入っていれば表示
				toggleNow = toggleNum;
				Debug.Log("now:"+toggleNow);
		}
		else toggleSet.SetActive(_toggle,false); //入っていなければ非表示に
	}

}
