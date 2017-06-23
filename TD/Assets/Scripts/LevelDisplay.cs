using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class LevelDisplay : MonoBehaviour {
	//UI Text field
	Text instruction;
	//castle object
	GameObject gameManager;
	//castle health
	int level;

	// Use this for initialization
	void Start () {
		instruction = GetComponent<Text> ();
		gameManager = GameObject.Find("Game Manager");
	}

	// Update is called once per frame
	void Update () {
		level = gameManager.GetComponent <GameManager> ().level;
		instruction.text = "Level " + level;
	}
}
