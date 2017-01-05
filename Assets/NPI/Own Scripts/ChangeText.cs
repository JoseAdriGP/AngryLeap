using UnityEngine;
using System.Collections;

public class ChangeText : MonoBehaviour {

	// Use this for initialization
	public GameObject pitcher;
	void Start () {
	
	}
	
	// Update is called once per frame
	//Modificamos el texto que tenemos donde se indica la rotación para que concuerde con el angulo que toma el lanzador o pitcher
	void Update () {
		GetComponent<TextMesh> ().text = "Rotation: " + pitcher.transform.rotation.y + " rad";
	}
}
