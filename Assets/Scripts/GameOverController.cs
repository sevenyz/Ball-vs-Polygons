using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

	Animator animator;
	Rigidbody2D rb2d;

	public GameObject gameOverText;
	
	public bool gameOver;

	void Awake() {
		animator = GetComponent<Animator>();	
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update () {
		if (gameOver) {
			gameOverText.SetActive(true);
			animator.SetBool("gameOver", true);
			rb2d.simulated = false;

			if (Input.GetKeyDown(KeyCode.Return)) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}
}
