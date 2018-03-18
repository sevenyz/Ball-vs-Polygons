using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

	MeshRenderer meshRenderer;

	public enum PlayerColor { White, Red, Green, Blue };
	public PlayerColor playerColor;

	public Material whiteMat, redMat, greenMat, blueMat;

	void Awake () {
		meshRenderer = GetComponent<MeshRenderer>();
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			ChangeColor(PlayerColor.Red, redMat);
		}

		if (Input.GetKeyDown(KeyCode.G)) {
			ChangeColor(PlayerColor.Green, greenMat);
		}

		if (Input.GetKeyDown(KeyCode.B)) {
			ChangeColor(PlayerColor.Blue, blueMat);
		}
	}

	public void ChangeColor (PlayerColor color, Material mat) {
		playerColor = color;
		meshRenderer.material = mat;
	}
}
