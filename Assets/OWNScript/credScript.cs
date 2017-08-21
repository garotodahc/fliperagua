using UnityEngine;
using System.Collections;

public class credScript : MonoBehaviour {

	int velocidade;
	float pos;
	// Use this for initialization
	void Start () {
		velocidade = 1;
		pos = 1.46f;
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate (0, velocidade *Time.deltaTime, 0);

		if(pos >= 1.46){
			new WaitForSeconds(3);
			Application.LoadLevel("MenuScene");
		}
	}
}
