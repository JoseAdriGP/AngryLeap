using UnityEngine;
using System.Collections;
using System;
using Leap.Unity;
using Leap;
public class GesturesDetector : MonoBehaviour {
	public delegate void GestureEvent();
	public delegate void PointEvent(Vector3 vector);
	//public static event GestureEvent Sit;
	//public static event GestureEvent Jump;
	//public static event GestureEvent Die;
	//public static event GestureEvent OpenMenu;
	//public static event GestureEvent CloseMenu;
	//public static event PointEvent Pointing;

	GameObject fingerFinal;
	GameObject menu;

	GameObject menuPointer;
	GameObject option1;
	GameObject option2;
	GameObject option3;
	GameObject option4;

	int count =0;
	int sample=10;

	float step;
	float speed=4000;

	Boolean menuOn;

	//Vector3 reference = new Vector3();
	LeapServiceProvider leapServiceProvider;
	// Use this for initialization
	void Start () {
		leapServiceProvider = FindObjectOfType<LeapServiceProvider> ();
		menuOn = false;
		menu = GameObject.Find ("Menu");
		menuPointer = GameObject.Find ("Pointer");
		fingerFinal = GameObject.Find ("FingerPointer");
		option1 = GameObject.Find ("Option1");
		option2 = GameObject.Find ("Option2");
		option3 = GameObject.Find ("Option3");
	}

	// Update is called once per frame
	void Update () {

		if (count > sample) {
			Frame f = leapServiceProvider.CurrentFrame;
			if (f.Hands.Count > 0) {
				// Apuntar
				// Detecta la posicion "seleccionar" y coloca un objeto en la punta del dedo indice de la mano que se registre como mano[0]
				if (!menuOn && !f.Hands [0].Fingers [0].IsExtended && f.Hands [0].Fingers [1].IsExtended && !f.Hands [0].Fingers [2].IsExtended && !f.Hands [0].Fingers [3].IsExtended && !f.Hands [0].Fingers [4].IsExtended) {
					step = speed * Time.deltaTime;
					fingerFinal.transform.position = Vector3.MoveTowards(fingerFinal.transform.position, f.Hands [0].Fingers [1].TipPosition.ToVector3 (), step);
				} else {
					fingerFinal.transform.position = new Vector3 (-100,0,-100);
				}
					
				// Abrir Menu
				// Si detecta la posición "cocodrilo dundee", abre el menu. Los if de dentro comprueban la posición de la mano y mueve la posición del curso para generar la navegabilidad en función de la posición de la mano
				if (f.Hands [0].Fingers [0].IsExtended && !f.Hands [0].Fingers [1].IsExtended && !f.Hands [0].Fingers [2].IsExtended && !f.Hands [0].Fingers [3].IsExtended && f.Hands [0].Fingers [4].IsExtended) {
					menu.transform.position = new Vector3 (0f,0.05f,-7.407f);
					menuOn = true;
					if(f.Hands[0].PalmPosition.y>option1.transform.position.y-0.25f && f.Hands[0].PalmPosition.y<option1.transform.position.y+0.25f){
						menuPointer.transform.position = new Vector3(menuPointer.transform.position.x,option1.transform.position.y,option1.transform.position.z);
					}
					if(f.Hands[0].PalmPosition.y>option2.transform.position.y-0.25f && f.Hands[0].PalmPosition.y<option2.transform.position.y+0.25f){
						menuPointer.transform.position = new Vector3(menuPointer.transform.position.x,option2.transform.position.y,option2.transform.position.z);
					}
					if(f.Hands[0].PalmPosition.y>option3.transform.position.y-0.25f && f.Hands[0].PalmPosition.y<option3.transform.position.y+0.25f){
						menuPointer.transform.position = new Vector3(menuPointer.transform.position.x,option3.transform.position.y,option3.transform.position.z);
					}

				}

				//Seleccionar en menu
				//Si detecta que tenemos la posición "puño cerrado", selecionará la opción que se encuentra selecionada por el cursor
				if(menuOn && !f.Hands [0].Fingers [0].IsExtended && !f.Hands [0].Fingers [1].IsExtended && !f.Hands [0].Fingers [2].IsExtended && !f.Hands [0].Fingers [3].IsExtended && !f.Hands [0].Fingers [4].IsExtended){
					if(menuPointer.transform.position.y==option1.transform.position.y){
						Debug.Log ("Estamos en la opción 1");
					}
					if(menuPointer.transform.position.y==option2.transform.position.y){
						Debug.Log ("Estamos en la opción 2");
					}
					if(menuPointer.transform.position.y==option3.transform.position.y){
						Debug.Log ("Saliendo");
						Application.Quit();
					}
				}
					
				//Cerrar menú
				//Si detecta la posición 3, cerrará el menú siempre y cuando esté abierto
				if (!f.Hands [0].Fingers [0].IsExtended && f.Hands [0].Fingers [1].IsExtended && f.Hands [0].Fingers [2].IsExtended && f.Hands [0].Fingers [3].IsExtended && !f.Hands [0].Fingers [4].IsExtended) {
					menuPointer.transform.position = new Vector3(menuPointer.transform.position.x,option1.transform.position.y,menuPointer.transform.position.z);
					menu.transform.position = new Vector3 (-100, 0, -100);
					menuOn=false;
				}
			}
			count = 0;
		}
		count++;
	}


}
