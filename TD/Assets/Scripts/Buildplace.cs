using UnityEngine;
using System.Collections;

public class Buildplace : MonoBehaviour {
	public GameObject towerPrefab;	// The Tower that should be built
	GameObject gameManager;
	int currentGold;				//current gold
	int towerPrice;					//tower price
	bool occupied;					//is buildspace occupied?
	GameObject tower;

	void Start() {
		gameManager = GameObject.Find ("Game Manager");
		occupied = false;
		towerPrice = 50;
	}

	void OnMouseOver() {
		//print ("mouse is over buildspace " + gameObject.name);
		if (Input.GetMouseButtonDown (0)) {
			if (!occupied) {
				currentGold = gameManager.GetComponent<GameManager> ().gold;	//get current gold
				if (towerPrice <= currentGold) {		//if you have enough gold
					// Build Tower above Buildplace
					tower = (GameObject)Instantiate (towerPrefab);
					tower.transform.position = transform.position + new Vector3 ((float)0, (float)0.05, (float)0);
					occupied = true;
					gameManager.GetComponent<GameManager> ().SubtractGold (towerPrice);
				} else {
					print ("NOT ENOUGH GOLD");
				}
			}
		}
		if (Input.GetMouseButtonDown (1)) {
			DestroyTower ();
		}
	}

	public void DestroyTower (){
		Destroy (tower);
		gameManager.GetComponent<GameManager> ().AddGold (towerPrice / 2);
		occupied = false;
	}

	public GameObject GetTower() {
		return tower;
	}

	public bool GetOccupied() {
		return occupied;
	}
}