using UnityEngine;
using System.Collections;

public class CountParticles_LOst : MonoBehaviour {

	public static float qtdeLost = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D(Collider2D coll){
		
		qtdeLost = qtdeLost + 1;
		Debug.LogError ("A quantidade de particulas e : " + qtdeLost);
		

	}
}
