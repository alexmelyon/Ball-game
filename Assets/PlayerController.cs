using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Vector3 cameraDelta = new Vector3(0, 5, -7);
	public float forceMultiply = 10F;
	public GameObject spawn;

	private bool isCollides = false;

	void Start() {
		transform.position = spawn.transform.position;
	}

	void Update () {
		PlaceCameraBehindTheSphere();
		MoveSphere();
	}

	void PlaceCameraBehindTheSphere() {
		Camera.main.transform.position = transform.position + cameraDelta;
	}

	void MoveSphere() {
		Vector3 force = new Vector3();
		if(Input.GetKey(KeyCode.W)) {
			force.z = 1;
		} else if(Input.GetKey(KeyCode.S)) {
			force.z = -1;
		}
		if(Input.GetKey(KeyCode.A)) {
			force.x = -1;
		} else if(Input.GetKey(KeyCode.D)) {
			force.x = 1;
		}
		if(Input.GetKey(KeyCode.Space)) {
			if(isCollides) {
				Debug.Log("JUMP");
				force.y = 50;
			}
		}
		GetComponent<Rigidbody>().AddForce(force * forceMultiply);
	}

	void OnCollisionEnter(Collision c) {
		isCollides = true;
	}

	void OnCollisionExit(Collision c) {
		isCollides = false;
	}

	void OnTriggerEnter(Collider c) {
		if(c.tag.Equals("Respawn")) {
			Debug.Log("RESPAWN " + c.gameObject.name);
			spawn = c.gameObject;
		} else if(c.tag.Equals("Abyss")) {
			transform.position = spawn.transform.position;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		}
	}
}
