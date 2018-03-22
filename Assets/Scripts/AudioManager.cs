using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

	public AudioSource jumpSound;
	public AudioSource deathSound;
	public AudioSource changeColorSound;
	public AudioSource blockPassedSound;
	public AudioSource levelCompletedSound;
	public AudioSource selectionSound, selectionSound2;
	public AudioSource backToWhiteSound;

	public AudioMixer audioMixer;

	public void PlaySelection () {
		selectionSound.Play();
	}

	public void PlayOnHover () {
		selectionSound2.Play();
	}

	public void SetMusicVolume (float volume) {
		audioMixer.SetFloat("musicVolume", volume);
	}

	public void SetSFXVolume (float volume) {
		audioMixer.SetFloat("sfxVolume", volume);
	}

}
