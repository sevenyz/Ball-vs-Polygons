using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	GameOverController controller;
	ColorChanger colorChanger;
	GameController gameController;

	Rigidbody2D rb2d;

	public AudioManager audioManager;

	public bool canMove;
	public bool canJump;
	public bool levelCompleted;

	public GameObject levelWonText;

	public GameObject explosion;

	public float jumpForce;
	public float moveSpeed;

	void Awake () {
		rb2d = GetComponent<Rigidbody2D>();
		controller = GetComponent<GameOverController>();
		colorChanger = GetComponent<ColorChanger>();
		gameController = GetComponent<GameController>();
	}

	private void Start() {
		canMove = false;
		canJump = false;
		
		levelCompleted = false;
	}
	
	void Update () {
		if (Input.GetKey(KeyCode.Space) && canJump) {
			rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}

		if (canMove) {
			rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
		}

		if (Input.GetKeyDown(KeyCode.Space) && !controller.gameOver && !gameController.isPaused) {
			audioManager.jumpSound.Play();
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "RedWall") {
			if (colorChanger.playerColor == ColorChanger.PlayerColor.Red) {
				Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());

				audioManager.blockPassedSound.Play();

			}
			else {
				controller.gameOver = true;
				canMove = false;
				canJump = false;

				Instantiate(explosion, transform.position, Quaternion.identity);

				audioManager.deathSound.Play();
			}
		}

		if (other.gameObject.tag == "GreenWall") {
			if (colorChanger.playerColor == ColorChanger.PlayerColor.Green) {
				Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());

				audioManager.blockPassedSound.Play();
			}
			else {
				controller.gameOver = true;
				canMove = false;
				canJump = false;

				Instantiate(explosion, transform.position, Quaternion.identity);

				audioManager.deathSound.Play();
			}
		}

		if (other.gameObject.tag == "BlueWall") {
			if (colorChanger.playerColor == ColorChanger.PlayerColor.Blue) {
				Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());

				audioManager.blockPassedSound.Play();
			}
			else {
				controller.gameOver = true;
				canMove = false;
				canJump = false;

				Instantiate(explosion, transform.position, Quaternion.identity);

				audioManager.deathSound.Play();
			}
		}

		if (other.gameObject.tag == "StdWall") {
			controller.gameOver = true;
			canMove = false;
			canJump = false;

			Instantiate(explosion, transform.position, Quaternion.identity);

			audioManager.deathSound.Play();
		}
	}

	private void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject.tag == "RedWall" || 
			other.gameObject.tag == "GreenWall" || 
			other.gameObject.tag == "BlueWall") {
				
				colorChanger.ChangeColor(ColorChanger.PlayerColor.White, colorChanger.whiteSprite);
				audioManager.backToWhiteSound.Play();
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "EndLevel") {
			canMove = false;
			canJump = false;
			levelCompleted = true;

			levelWonText.SetActive(true);

			audioManager.levelCompletedSound.Play();
		}
	}
}
