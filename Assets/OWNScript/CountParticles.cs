using UnityEngine;
using System.Collections;

public class CountParticles : MonoBehaviour {

	int qtde = 0;
	public float media = 150f;
	public static float pontos;
	public static bool chamaSplashPause;
	// Use this for initialization
	void Start () {
		chamaSplashPause=false;
	//	qtde = ParticleGenerator.numero;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerExit2D(Collider2D coll){


			
		qtde = qtde + 1;

		/*if ((qtde >= media)) {
			Time.timeScale = 0;
			Debug.LogWarning ("Vc n passou de fase");

		    Application.LoadLevel("lostScene");
				} 
		if((qtde < media) && (stage.scene == 1) && (CameraMove.minhaPontuacao >= 30) ){
			Time.timeScale = 0;
			Debug.LogWarning ("Vc  passou de fase");
			
			Application.LoadLevel("winScene");
		}	*/
				

				
	}
}
