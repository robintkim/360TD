using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	public GameObject spawnPrefab;
	bool gameStarted = false;
	GameObject gameManager;

	public void Awake() {
		gameManager = GameObject.Find ("Game Manager");
	}

	public void OnClick () {
		if (!gameStarted) {
			gameManager.GetComponent<GameManager> ().StartGame ();
			gameStarted = true;
		}
	}
}
