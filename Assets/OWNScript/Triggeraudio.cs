using UnityEngine;
using System.Collections;

public class Triggeraudio : MonoBehaviour {

	
	
	public AudioClip myclip;
	
	

	
	
	void uptade ()
	{
		if(colisaoSementes.colide == true)
		{
			AudioSource.PlayClipAtPoint(myclip,transform.position);
		}
	}

}
