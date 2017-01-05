using UnityEngine;
using System.Collections;

public class PitcherWorks : MonoBehaviour {
	public float speed;
	Rigidbody rb;
	public GameObject top;
	public GameObject bottom;
	// Use this for initialization
	float x;
	float y;
	float z;
	float mod;
	Vector3 direction;

	void OnCollisionEnter(Collision col){
		//Se calcula el vector de dirección y velocidad que vamos a aplicar al proyectil
		x = top.transform.position.x - bottom.transform.position.x;
		y = top.transform.position.y - bottom.transform.position.y;
		z = top.transform.position.z - bottom.transform.position.z;
		mod = Mathf.Sqrt (x*x+y*y+z*z);
		x = x / mod;
		y = y / mod;
		z = z / mod;
		direction = new Vector3 (x,y,z);
		//Si la colision se efectúa con un elemento que se llame de las dos formas indicadas, aplicamos el vector de movimiento.
		if (col.gameObject.name == "Proyectil1" || col.gameObject.name == "Proyectil2") {
			
			rb = col.gameObject.GetComponent<Rigidbody> ();
			rb.AddRelativeForce (direction * speed, ForceMode.Impulse);
		}
	}
}
