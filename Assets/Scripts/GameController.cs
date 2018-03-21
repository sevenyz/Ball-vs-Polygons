using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	PlayerController playerController;
	GameOverController gameOverController;

	[SerializeField]
	bool hasStarted;
	[SerializeField]
	bool isPaused;

	public GameObject startText;
	public GameObject pauseText;

	void Awake() {
		playerController = GetComponent<PlayerController>();	
		gameOverController = GetComponent<GameOverController>();
	}

	void Start () {
		hasStarted = false;
		isPaused = false;
	}
	
	void Update () {
		if (!gameOverController.gameOver) {

			if (!hasStarted) {
				BlockPlayerMovement(true);
				startText.gameObject.SetActive(true);

				if (Input.GetKeyDown(KeyCode.Space)) {
					hasStarted = true;
					BlockPlayerMovement(false);
					startText.gameObject.SetActive(false);
				}
			}

			if (hasStarted) {

				if (!isPaused) {
					if (Input.GetKeyDown(KeyCode.Escape)) {
						PauseGame(true);
					}
				} 
				else {
					if (Input.GetKeyDown(KeyCode.Escape)) {
						PauseGame(false);
					}
				}
			}
		}
	}

	void PauseGame (bool paused) {
		if (paused) {
			isPaused = true;
			Time.timeScale = 0;
			pauseText.gameObject.SetActive(true);
			BlockPlayerMovement(true);
		} else {
			isPaused = false;
			Time.timeScale = 1;
			pauseText.gameObject.SetActive(false);
			BlockPlayerMovement(false);
		}
	}

	void BlockPlayerMovement (bool block) {
		if (block) {
			playerController.canJump = false;
			playerController.canMove = false;
		} else {
			playerController.canJump = true;
			playerController.canMove = true;
		}
	}

	public void LoadMenu () {
		SceneManager.LoadScene(0);
	}
}
