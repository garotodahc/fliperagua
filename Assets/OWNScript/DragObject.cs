using UnityEngine;
using System.Collections;

public class DragObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDrag(){
		
		Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		point.z = gameObject.transform.position.z;
		
		gameObject.transform.position = point;
		
		Cursor.visible = false;
		
		
	}

	void OnMouseUp(){
		
		Cursor.visible = true;
		
	}



}
