using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	Vector3 offset;

	public GameObject target;

	void Start () {
		offset = target.transform.position - transform.position;
	}
	
	void LateUpdate () {
		transform.position = new Vector3(target.transform.position.x - offset.x, transform.position.y, transform.position.z);
	}
}
 