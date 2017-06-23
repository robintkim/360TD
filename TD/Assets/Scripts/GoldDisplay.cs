using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class GoldDisplay : MonoBehaviour {
	//UI Text field
	Text instruction;

	//castle object
	GameObject gameManager;

	//gold amount
	int gold;

	// Use this for initialization
	void Start () {
		instruction = GetComponent<Text> ();
		gameManager = GameObject.Find("Game Manager");
	}

	// Update is called once per frame
	void Update () {
		gold = gameManager.GetComponent<GameManager> ().gold;
		instruction.text = "Gold: " + gold;
	}
}