using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	Collision2D cel;



	void start(){

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.name == "Destroy2D Mesh") {
			Destroy2D terrain = GameObject.Find("Destroy2D Object").GetComponent<Destroy2D>();
			terrain.destroyAt(transform.position, 1.0f,0.5f);
			Destroy(GetComponent<PolygonCollider2D>());//destroy o 2d collider
			//Destroy(this);
			//gameObject.AddComponent<PolygonCollider2D>();//readiciona o 2d collider , refazendo o form de colisao

		}

	}

}