using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIBEhav : MonoBehaviour {
	Text meuTexto;
	public static int pontosGeral;
	public static bool active;
	// Use this for initialization
	void Start () {



		meuTexto = gameObject.GetComponent<Text> ();
		meuTexto.text ="" + PontuacaoManager.getScore();
	}
	
	// Update is called once per frame
	void Update () {
		pontosGeral = PontuacaoManager.getScore();

		meuTexto.text = "" + pontosGeral;

		if (CameraMove.newPosition.y == CameraMove.outraPOs && (pontosGeral < 0)) {

						active = true;
						Application.LoadLevel ("lostScene");
				} 
		if (CameraMove.newPosition.y == CameraMove.outraPOs && (pontosGeral >= 0)) {
			
			active = false;

			//Application.LoadLevel ("lostScene");
		} 
		}
}                                   