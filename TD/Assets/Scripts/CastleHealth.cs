using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CastleHealth : MonoBehaviour {


	public int currentHealth;									//current health
//	public Slider healthSlider;									//Reference to the UI's health bar.
	public AudioClip deathClip;									//The audio clip to play when the player dies.

	int maxHealth;								//max health
	bool isDead;
	GameObject gameManager;

	void Awake() {
		maxHealth = 500;
		currentHealth = maxHealth;
		gameManager = GameObject.Find ("Game Manager");
	}
		
	public void TakeDamage(int amount) {
		currentHealth -= amount;
		if (currentHealth <= 0) {
			isDead = true;
		}
		if (isDead) {
			gameManager.GetComponent<GameManager> ().GameOver ();
			isDead = false;
		}
	}
}
