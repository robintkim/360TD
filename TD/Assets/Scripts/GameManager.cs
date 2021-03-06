using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public int gold;
	public int level;
	public GameObject spawnPrefab;
	public GameObject gameOverPanel;
	public Text gameOverText;

	bool gameStarted;
	bool gameOver;
	float gameOverDisplayTime;
	float gameOverDisplayDuration = 5.0f;
	float levelDuration = 15.0f;
	float nextLevelTime;

	GameObject[] spawnPoints = new GameObject[4];

	// Use this for initialization
	void Awake () {
		gold = 500;
		level = 1;
		nextLevelTime = 0.0f;
		gameStarted = false;
		gameOverPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (gameStarted) {
			if (nextLevelTime == 0.0f) {
				nextLevelTime = Time.time + levelDuration;
				//print ("Current Level: " + level);
				//print ("Current Time: " + Time.time);
				//print ("Next Level Time: " + nextLevelTime);
			}
			if (Time.time > nextLevelTime) {
				IncreaseLevel ();
			}
		}
		if (gameOver) {
			if (Time.time >= gameOverDisplayTime) {
				SceneManager.LoadScene ("scene");
			}
		}
	}

	public void AddGold(int amt) {
		gold += amt;
	}

	public void SubtractGold(int amt) {
		gold -= amt;
	}

	void IncreaseLevel() {
		level += 1;
		nextLevelTime = Time.time + levelDuration;
		//print ("Current Level: " + level);
		//print ("Next Level Time: " + nextLevelTime);
	}

	public void StartGame() {
		gameStarted = true;

		spawnPoints[0] = (GameObject)Instantiate(spawnPrefab);
		spawnPoints[0].transform.position = new Vector3 ((float)9, (float)0.5, (float)0);

		spawnPoints[1] = (GameObject)Instantiate(spawnPrefab);
		spawnPoints[1].transform.position = new Vector3 ((float)0, (float)0.5, (float)-9);

		spawnPoints[2] = (GameObject)Instantiate(spawnPrefab);
		spawnPoints[2].transform.position = new Vector3 ((float)0, (float)0.5, (float)9);

		spawnPoints[3] = (GameObject)Instantiate(spawnPrefab);
		spawnPoints[3].transform.position = new Vector3 ((float)-9, (float)0.5, (float)0);
	}

	public void GameOver() {
		gameOverPanel.SetActive (true);
		gameOverText.text = "Game Over!";
		gameOver = true;
		gameOverDisplayTime = Time.time + gameOverDisplayDuration;
	}

}
