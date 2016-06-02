using UnityEngine;
using System.Collections;

public class MoveFuda : MonoBehaviour {
    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown() {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag() {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.position=(new Vector3(Mathf.Clamp(currentPosition.x,0,112),Mathf.Clamp(currentPosition.y,0,0),Mathf.Clamp(currentPosition.z,0,20)));
        //transform.position = currentPosition;

    }

    void OnCollisionEnter(Collision other){
  		GameObject.Destroy(other.gameObject);
  	}

    void Awake(){
  		 DontDestroyOnLoad(this);
  	}

    void update(){

    }
}
