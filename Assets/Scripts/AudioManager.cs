using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource jumpSound;
	public AudioSource deathSound;
	public AudioSource changeColorSound;
	public AudioSource blockPassedSound;
	public AudioSource levelCompletedSound;
	public AudioSource selectionSound;
	public AudioSource backToWhiteSound;

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void PlaySelection () {
		selectionSound.Play();
	}
}
