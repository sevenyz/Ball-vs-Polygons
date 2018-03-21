using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

	//MeshRenderer meshRenderer;
	SpriteRenderer spriteRenderer;

	public enum PlayerColor { White, Red, Green, Blue };
	public PlayerColor playerColor;

	//public Material whiteMat, redMat, greenMat, blueMat;
	public Sprite whiteSprite, redSprite, greenSprite, blueSprite;

	void Awake () {
		//meshRenderer = GetComponent<MeshRenderer>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			ChangeColor(PlayerColor.Red, redSprite);
		}

		if (Input.GetKeyDown(KeyCode.G)) {
			ChangeColor(PlayerColor.Green, greenSprite);
		}

		if (Input.GetKeyDown(KeyCode.B)) {
			ChangeColor(PlayerColor.Blue, blueSprite);
		}
	}

	public void ChangeColor (PlayerColor color, Sprite sprite) {
		playerColor = color;
		spriteRenderer.sprite = sprite;
		//meshRenderer.material = mat;
	}
}
