using UnityEngine;
using System.Collections;

public class aboutScript : MonoBehaviour {




	
	// Update is called once per frame


		IEnumerator Start(){
			AsyncOperation async = Application.LoadLevelAsync("W1S1Scene");
			yield return async;
			Debug.Log("Loading complete");
		}
	




}
