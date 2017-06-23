using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class CastleHealthDisplay : MonoBehaviour {
	//UI Text field
	Text instruction;
	//castle object
	GameObject castle;
	//castle health
	int health;

	// Use this for initialization
	void Start () {
		instruction = GetComponent<Text> ();
		castle = GameObject.Find("Castle");
	}

	// Update is called once per frame
	void Update () {
		health = castle.GetComponent <CastleHealth> ().currentHealth;
		instruction.text = "Castle Health: " + health;
	}
}
