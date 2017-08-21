using UnityEngine;
using System.Collections;

public class folowwcursor : MonoBehaviour {

	public GameObject particle;

	// Use this for initialization
	void Start () {
		  
	}
	
	// Update is called once per frame
	void Update () {
	

			if (Input.GetButtonDown("Fire1")) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray))
					Instantiate(particle, transform.position, transform.rotation);
				
			}
		}
	}
	