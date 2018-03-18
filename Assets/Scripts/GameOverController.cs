using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

	public GameObject gameOverText;
	
	public bool gameOver;

	void Start () {
		
	}
	
	void Update () {
		if (gameOver) {
			gameOverText.SetActive(true);

			if (Input.GetKeyDown(KeyCode.R)) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}
}
