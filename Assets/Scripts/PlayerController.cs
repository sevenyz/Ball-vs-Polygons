using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	GameOverController controller;
	ColorChanger colorChanger;
	
	Rigidbody2D rb2d;

	bool canMove;
	bool canJump;
	public bool levelCompleted;

	public GameObject levelWonText;

	public float jumpForce;
	public float moveSpeed;

	void Awake () {
		rb2d = GetComponent<Rigidbody2D>();
		controller = GetComponent<GameOverController>();
		colorChanger = GetComponent<ColorChanger>();
	}

	private void Start() {
		canMove = true;
		canJump = true;
		
		levelCompleted = false;
	}
	
	void Update () {
		if (Input.GetKey(KeyCode.Space) && canJump) {
			rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}

		if (canMove) {
			rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "RedWall") {
			if (colorChanger.playerColor == ColorChanger.PlayerColor.Red) {
				Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
			}
			else {
				controller.gameOver = true;
				canMove = false;
				canJump = false;
			}
		}

		if (other.gameObject.tag == "GreenWall") {
			if (colorChanger.playerColor == ColorChanger.PlayerColor.Green) {
				Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
			}
			else {
				controller.gameOver = true;
				canMove = false;
				canJump = false;
			}
		}

		if (other.gameObject.tag == "BlueWall") {
			if (colorChanger.playerColor == ColorChanger.PlayerColor.Blue) {
				Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
			}
			else {
				controller.gameOver = true;
				canMove = false;
				canJump = false;
			}
		}

		if (other.gameObject.tag == "StdWall") {
			controller.gameOver = true;
			canMove = false;
			canJump = false;
		}
	}

	private void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject.tag == "RedWall" || 
			other.gameObject.tag == "GreenWall" || 
			other.gameObject.tag == "BlueWall") {
				
				colorChanger.ChangeColor(ColorChanger.PlayerColor.White, colorChanger.whiteSprite);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "EndLevel") {
			canMove = false;
			canJump = false;
			levelCompleted = true;

			levelWonText.SetActive(true);
		}
	}
}
