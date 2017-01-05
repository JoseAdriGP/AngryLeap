using UnityEngine;
using System.Collections;

public class ColorSolid : MonoBehaviour {
	public Color ObjectColor;

	private Color currentColor;
	private Material materialColored;

	// Lo que hace esta clase es, a partir de un color que le pasamos, genera un material que aplica al objeto que posea este script
	void Update()
	{
		if (ObjectColor != currentColor)
		{
			//helps stop memory leaks
			if (materialColored != null)
				UnityEditor.AssetDatabase.DeleteAsset(UnityEditor.AssetDatabase.GetAssetPath(materialColored));

			//create a new material
			materialColored = new Material(Shader.Find("Diffuse"));
			materialColored.color = currentColor = ObjectColor;
			this.GetComponent<Renderer>().material = materialColored;
		}
	}
}
