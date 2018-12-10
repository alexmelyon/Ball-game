using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public string sceneName;

	void Start () {
		GetComponent<Button>().onClick.AddListener(()  => SceneManager.LoadScene(sceneName));
	}
}
