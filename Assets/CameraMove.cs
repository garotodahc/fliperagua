using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour 
{
	public float cameraVelocity;
	private Vector3 offset;
	private Vector3 oldPosition;
	public static Vector3 newPosition;
	public static int outraPOs;
	public int levelPoints;
	public int scene;
	public string level;

	Destroy minhaDestruc;
	public static int pontuacaoCamera;
	public bool flag;

	// Use this for initialization
	void Start ()
	{
		flag = false;
		offset = transform.position;
		oldPosition = offset;
		//levelPoints = 0;
		/*************Pmateus**************/
		newPosition.y = 0;
		PontuacaoManager.verifyLevel (level);
		/**********************************/
		minhaDestruc = new Destroy();
		//Time.timeScale = 1;
		pontuacaoCamera = +levelPoints;
	//	PlayerPrefs.SetInt (levelPoints);
	}

	void Uptade(){

		}
	
	// Update is called once per frame
	void LateUpdate () 
	{

				//minhaPontuacao = colisaoSementes.pontos;
				/*if (oldPosition.y < player.transform.position.y) 
		{
			//newPosition.x = player.transform.position.x;
			newPosition.x = oldPosition.x;
			newPosition.y = oldPosition.y;
			newPosition.z = oldPosition.z;
			transform.position = newPosition;
			oldPosition = newPosition;
		} else
		{*/
				//newPosition.x = player.transform.position.x;

		         managerCamera ();
				newPosition.x = oldPosition.x;
				newPosition.y = oldPosition.y + cameraVelocity;
				newPosition.z = oldPosition.z;
				transform.position = newPosition;
				oldPosition = newPosition;

				
		}

	void managerCamera(){

		switch(scene){
			
		case 1 :
			
			outraPOs = -15;
			if (newPosition.y <= outraPOs) {
				
			//	Debug.Log ("alterou a camera");	

				Application.LoadLevel(level);
			}

			break;
			
		case 2 :
			
			outraPOs = -32;
			if (newPosition.y <= outraPOs) {
				
			//	Debug.Log ("alterou a camera");	

				Application.LoadLevel(level);
			}

			break;
			
		case 3 :
			
			outraPOs = -32;
			if (newPosition.y < outraPOs) {
				
			//	Debug.Log ("alterou a camera");	
			
				Application.LoadLevel(level);
			}

			break;
		case 4 :
			
			outraPOs = -46;
			if (newPosition.y < outraPOs) {
				
			//	Debug.Log ("alterou a camera");	

				Application.LoadLevel(level);
			}

			break;
		case 5 :
			
			outraPOs = -45;
			if (newPosition.y < outraPOs) {
			//	
			//	Debug.Log ("alterou a camera");	
				//
				Application.LoadLevel(level);
			}
			break;
		case 6 :
			
			outraPOs = -53;
			if (newPosition.y < outraPOs) {
				
			//	Debug.Log ("alterou a camera");	

				Application.LoadLevel(level);
			}

			break;
		case 7 :
			
			outraPOs = -72;

			if (newPosition.y < outraPOs) {

			//	Debug.Log ("alterou a camera");	

				Application.LoadLevel(level);
			}

			break;
		case 8 :
			
			outraPOs = -72;
			if (newPosition.y < outraPOs) {
				
				//Debug.Log ("alterou a camera");	

				Application.LoadLevel(level);
			}

			break;
		case 9 :
			
			outraPOs = -81;
			if (newPosition.y < outraPOs) {
				
				//Debug.Log ("alterou a camera");	

				Application.LoadLevel(level);
			}

			break;
		}

	}


	void managerScore(){

		while(GUIBEhav.pontosGeral > 0  && GUIBEhav.pontosGeral<= 10){

			flag = true;
		}
			flag = false;


	}

 }
	

