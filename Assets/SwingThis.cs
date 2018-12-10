using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingThis : MonoBehaviour {
	
	public Vector3 eulerAngles;
	public float time;

	void Update () {
		float x = Mathf.Sin(Time.time) * eulerAngles.x / time;
		float y = Mathf.Sin(Time.time) * eulerAngles.y / time;
		float z = Mathf.Sin(Time.time) * eulerAngles.z / time;
		transform.rotation = Quaternion.Euler(x, y, z);
	}
}
