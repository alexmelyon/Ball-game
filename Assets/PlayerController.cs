using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

	public GameObject cameraParent;
	public Vector3 cameraDelta = new Vector3(0, 5, -7);
	public float forceMultiply = 10F;
	public GameObject spawn;

	private int collidesCount = 0;
//	private Vector3 lastPos;
	private float angle;
	private bool doubleJump = false;
	private bool doubleJumpUsed = false;

	void Start()
	{
		transform.position = spawn.transform.position;
//		lastPos = transform.position;

//		Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Glass"));
	}

	void Update()
	{
		PlaceCameraBehindTheSphere();
		MoveSphere();
		if(Input.GetKey(KeyCode.Escape)) {
			SceneManager.LoadScene("Menu");
		}
	}

	void PlaceCameraBehindTheSphere()
	{
		Camera.main.transform.position = transform.position + cameraDelta;

		// TODO Use angle
		// cameraParent.transform.position = transform.position;
		// angle = Vector3.SignedAngle(Vector3.forward, transform.position - lastPos, Vector3.up);
		// cameraParent.transform.rotation = Quaternion.Euler(0, angle, 0);
		// lastPos = transform.position;
	}

	void MoveSphere()
	{
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
			if(collidesCount > 0) {
				Debug.Log("JUMP");
				force.y = 50;
			} else if(doubleJump && !doubleJumpUsed) {
				Debug.Log("DOUBLE JUMP " + GetComponent<Rigidbody>().velocity.y);
				force.y = 50;
				doubleJumpUsed = true;
			}
		}
		// TODO Use angle
		// force = Quaternion.Euler(0, angle, 0) * force;
		GetComponent<Rigidbody>().AddForce(force * forceMultiply);
	}

	void OnCollisionEnter(Collision c)
	{
		collidesCount++;
		doubleJumpUsed = false;
//		if(c.gameObject.tag.Equals("Glass")) {
//			Physics.IgnoreCollision(GetComponent<Collider>(), c.collider);
//		}
	}

	void OnCollisionExit(Collision c)
	{
		collidesCount--;
	}

	void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.CompareTag("Respawn")) {
			Debug.Log("RESPAWN " + c.gameObject.name);
			spawn = c.gameObject;
		} else if(c.gameObject.CompareTag("Abyss")) {
			transform.position = spawn.transform.position;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		} else if(c.gameObject.CompareTag("DoubleJump")) {
			doubleJump = true;
		} else if(c.gameObject.CompareTag("Finish")) {
			StartCoroutine(LoadAuthors());
		}
	}

	void OnTriggerExit(Collider c) {
		if(c.gameObject.CompareTag("DoubleJump")) {
			doubleJump = false;
		}
	}

	IEnumerator LoadAuthors() {
		yield return new WaitForSeconds(3F);
		SceneManager.LoadScene("Authors");
	}
}
