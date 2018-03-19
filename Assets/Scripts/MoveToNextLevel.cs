using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour {

	PlayerController playerController;

	void Awake () {
		playerController = GetComponent<PlayerController>();
	}
	
	void Update () {
		if (playerController.levelCompleted) {
			if (Input.GetKeyDown(KeyCode.Return)) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
		}
	}
}
