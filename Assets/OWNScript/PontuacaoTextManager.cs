using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PontuacaoTextManager : MonoBehaviour {
	private static Text myText;
	private static readonly string initText = "Pontos: ";
	public static int pontosGeral;
	public static int fontSize = 14;

	/*Variaveis para controle de efeito no HUD pontuaçao*/
	private static bool pontuou = false;
	private static bool aindaAumentando = false;
	private static int varControle = 0;
	private static int tamanhoAaumentar = 1;
	/*Isso porque na minha tela qnd passa de 20 (o tamanho do text) ele some da tela. Entao coloquei o numero do limite
	 baixo. Mas eh um bom numero ja...*/
	private static int limitePorUpdate = 5;
	
	// Use this for initialization
	
	private void Start () {
		
		myText = gameObject.GetComponent<Text> ();
		myText.font = (Font)Resources.Load("Fonts/JOKERMAN", typeof(Font));
		myText.fontSize = fontSize;
		myText.color = Color.white;
		
		myText.text = initText + PontuacaoManager.getScore();
		setPosition ();
	}
	
	// Update is called once per frame
	private void Update () {
		myText.text = initText + PontuacaoManager.getScore();

		if (pontuou == true) {
			if (varControle<=limitePorUpdate && aindaAumentando == true) {
				myText.fontSize += tamanhoAaumentar;
				varControle++;
			} else{
				aindaAumentando = false;
				myText.fontSize -= tamanhoAaumentar;
				varControle--;
				if(varControle <= 0){
					varControle=0;
					pontuou = false;
				}
			}

		}

		setPosition ();
	}
	
	/*
	float y 35% da tela pra cima
	float x 4% da tela pro meio
	 */
	private void setPosition() {
		myText.rectTransform.anchoredPosition = new Vector2((float)(Screen.width * 0.04), (float)(Screen.height * 0.35));
	}

	public static void efeitoAoPontuar(){
		pontuou = true;
		aindaAumentando = true;
	}
}
