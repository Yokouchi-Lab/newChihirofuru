using UnityEngine;
using System.Collections;

public class example : MonoBehaviour {
    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown() {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag() {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.position = currentPosition;
    }

    void update(){
      transform.position=(new Vector3(Mathf.Clamp(transform.position.x,0,16),Mathf.Clamp(transform.position.y,0,0),Mathf.Clamp(transform.position.z,0,2)));
    }
}
