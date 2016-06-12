using UnityEngine;
using System.Collections;

public class GetFuda : MonoBehaviour {
	// オブジェクト
	[SerializeField] public GameObject fuda;
	[SerializeField] public GameObject voice;
	[SerializeField] public GameObject yuka;
	// ***確認用***
	// クリックした札のObjectname
	[SerializeField] private string selectedGameObjectname;
	// 札と音声の番号
	[SerializeField] private int fudaNum = 0;
	[SerializeField] private int voiceNum = 0;
	// ************

	// Use this for initialization
	void Start () {
		voice = GameObject.Find ("Voice");
		yuka = GameObject.Find ("Plane");
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			if (Physics.Raycast(ray, out hit)) {
				selectedGameObjectname = hit.collider.gameObject.name;
				fuda = GameObject.Find( selectedGameObjectname );
				if ( fuda != null ) {
					if (fuda != yuka) {
						// ***確認用***
						fudaNum = fuda.GetComponent<FudaData> ().fudanum;
						//voiceNum = voice.GetComponent<Voice> ().num;
						// ************
						if (fudaNum == voiceNum) {
							// とりあえずオブジェクト消すだけ
							Destroy (hit.collider.gameObject);
						} else {
							// とりあえずメッセージ出すだけ
							Debug.LogWarning ("miss");
						}
					} else {
						Debug.LogWarning ("it's a floor");
					}
				} else {
					Debug.LogWarning ("set Script!");
				}
			}
		}
	}
}
