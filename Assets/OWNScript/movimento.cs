using UnityEngine;
using System.Collections;

public class movimento : MonoBehaviour {


	int velocidade = 5;
	int count;
	float tempo= 60.0f;
	int i = 0;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
				
//		transform.Translate (0,0, -velocidade*Time.deltaTime);
				

						tempo =-tempo * Time.deltaTime;
			            Debug.Log("tempo = "+tempo);
						if (tempo == 0) {
			Application.LoadLevel("splash1");
								//count = count + 1;
							/*	switch (count) {

								case 1:
										Instantiate (objeto, new Vector3 (0, 0, velocidade * 2.0f), transform.rotation);
										Destroy (this.gameObject);
										new WaitForSeconds(5);
										tempo = 5; 
										break;
								case 2:
										Instantiate (objeto1, new Vector3 (0, 0, velocidade * 2.0f), transform.rotation);
										Destroy (objeto1, 2f);
				new WaitForSeconds(5);
				tempo = 10;
										break;
								case 3:
										Instantiate (objeto2, new Vector3 (0, 0, velocidade * 2.0f), transform.rotation);
										Destroy (objeto2, 5f);
				new WaitForSeconds(5);
										tempo = 15;
										break;
								case 4:
										Instantiate (objeto3, new Vector3 (0, 0, velocidade * 2.0f), transform.rotation);
										Destroy (objeto3, 5f);
				new WaitForSeconds(5);
										tempo = 20;
										break;
								case 5:
										Instantiate (objeto4, new Vector3 (0, 0, velocidade * 2.0f), transform.rotation);
										Destroy (objeto4, 5f);
				new WaitForSeconds(5);
										tempo = 25;
										break;
								default:

										print ("e thiago vc nao conseguiu de novo");
					                    break;
								}*/
						}
		
				}
} 
