using UnityEngine;
using System.Collections;

public class TouchButtom : MonoBehaviour {
	// Use this for initialization
	GameObject b1;
	GameObject p1;
	GameObject r1;

	GameObject b2;
	GameObject p2;
	GameObject r2;

	GameObject lf;
	GameObject rg;
	public GameObject pch;

	void Start () {
		b1 = GameObject.Find ("Button1");
		p1 = GameObject.Find ("Proyectil1");
		r1 = GameObject.Find ("Respawn1");

		b2 = GameObject.Find ("Button2");
		p2 = GameObject.Find ("Proyectil2");
		r2 = GameObject.Find ("Respawn2");

		lf = GameObject.Find ("Left");
		rg = GameObject.Find ("Right");
	}
	
	// Update is called once per frame
	void Update () {
		//El código siguiente determina si un objeto entra en contacto con alguna de las esferas que determinan botones.

		//Respawn of projectiles
		if(distancePointsSphere(b1)<=b1.GetComponent<SphereCollider>().radius/2){
			p1.transform.position = new Vector3(r1.transform.position.x,r1.transform.position.y+0.2f,r1.transform.position.z);
		}
		if(distancePointsSphere(b2)<=b2.GetComponent<SphereCollider>().radius/2){
			p2.transform.position = new Vector3(r2.transform.position.x,r2.transform.position.y+0.2f,r2.transform.position.z);
		}

		//Turn the catapult
		if(distancePointsSphere(lf)<=lf.GetComponent<SphereCollider>().radius/2){
			if(pch.transform.rotation.y-1.0f>-1.4f){
				Quaternion originalRot = pch.transform.rotation;    
				pch.transform.rotation = originalRot * Quaternion.AngleAxis(-1.0f, Vector3.up);	
			}
		}
		if(distancePointsSphere(rg)<=rg.GetComponent<SphereCollider>().radius/2){
			if(pch.transform.rotation.y+1.0f<1.4f){
				Quaternion originalRot = pch.transform.rotation;    
				pch.transform.rotation = originalRot * Quaternion.AngleAxis(1.0f, Vector3.up);	
			}			
		}


	}

	//Esta función calcula la distancia entre dos puntos
	float distancePointsSphere(GameObject go){
		float distancia;
		float X = go.transform.position.x - this.transform.position.x;
		float Y = go.transform.position.y - this.transform.position.y;
		float Z = go.transform.position.z - this.transform.position.z;

		X = X*X;
		Y = Y*Y;
		Z = Z*Z;

		distancia = X + Y + Z;
		distancia = Mathf.Sqrt (distancia);
		return distancia;
	}
}
