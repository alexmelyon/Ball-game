using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThis : MonoBehaviour {

	public Vector3 eulerAngles;

	void Update () {
		transform.Rotate(eulerAngles * Time.deltaTime);
	}
}
