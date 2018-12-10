using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthorsController : MonoBehaviour {

	public RectTransform text;
	public float moveSpeed = 10;
	public float endTime = 150;

	private float loadTime;

	void Start() {
		loadTime = Time.time;
	}

	void Update () {

		text.position = new Vector2(text.position.x, text.position.y + moveSpeed * Time.deltaTime);

		if((Time.time - loadTime) > endTime || Input.GetKey(KeyCode.Escape)) {
			SceneManager.LoadScene("Menu");
		}
	}
}
