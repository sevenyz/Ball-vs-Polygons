using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

	Rigidbody2D rb2d;
	SpriteRenderer spriteRenderer;
	
	public GameObject gameOverText;
	
	public bool gameOver;

	void Awake() {	
		rb2d = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update () {
		if (gameOver) {
			gameOverText.SetActive(true);
			rb2d.simulated = false;

			spriteRenderer.enabled = false;

			if (Input.GetKeyDown(KeyCode.Return)) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}
}
