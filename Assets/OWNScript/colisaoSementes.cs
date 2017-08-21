using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class colisaoSementes : MonoBehaviour {

	public GameObject objeto;
	public static int pontosreal;
	public static bool colide;
	public AudioClip myclip;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void  OnTriggerEnter2D(Collider2D other)
	{

		if(other.gameObject.CompareTag("DynamicParticle"))
		{
			colide = true;
			Instantiate(objeto, transform.position,transform.rotation);
			AudioSource.PlayClipAtPoint(myclip,transform.position);
			Destroy(gameObject);
			PontuacaoManager.addScore(PontuacaoManager.pontosPorSemente);
		}
		colide = false;
	}
}
