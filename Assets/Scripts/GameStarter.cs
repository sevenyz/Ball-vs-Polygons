using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour {

	bool hasStarted;

	public GameObject startText;

	void Start () {
		hasStarted = false;
	}
	
	void Update () {
		if (!hasStarted) {
			Time.timeScale = 0;
			startText.gameObject.SetActive(true);

			if (Input.GetKeyDown(KeyCode.Space)) {
				hasStarted = true;
				Time.timeScale = 1;
				startText.gameObject.SetActive(false);
			}
		}
	}
}
