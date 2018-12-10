using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThis : MonoBehaviour {

	public Transform start;
	public Transform end;
	public float time;

	void Update () {
		float x = Mathf.Sin(Time.time) * (end.position.x - start.position.x) / time + (end.position.x - start.position.x) / 2;
		float y = Mathf.Sin(Time.time) * (end.position.y - start.position.y) / time + (end.position.y - start.position.y) / 2;
		float z = Mathf.Sin(Time.time) * (end.position.z - start.position.z) / time + (end.position.z - start.position.z) / 2;
		transform.position = new Vector3(x + start.position.x, y + start.position.y, z + start.position.z);
	}
}
