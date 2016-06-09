using UnityEngine;
using System.Collections;

public class MoveFuda : MonoBehaviour {
    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown() {
      if(GameObject.FindWithTag("check") == null){
        if(this.tag == "playerfuda"){
          this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
          this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
      }
    }

    void OnMouseDrag() {
      if(GameObject.FindWithTag("check") == null){
        if(this.tag == "playerfuda"){
          Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
          Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
          transform.position=(new Vector3(Mathf.Clamp(currentPosition.x,0,112),Mathf.Clamp(currentPosition.y,0,0),Mathf.Clamp(currentPosition.z,-40,-20)));
          //transform.position = currentPosition;
        }
      }
    }

    void OnCollisionEnter(Collision other){

  	}

    void Awake(){
  		 DontDestroyOnLoad(this);
  	}

    void update(){

    }
}
