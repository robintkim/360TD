using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {


	int attackDamageBase = 10;           // The amount of health taken away per attack.
	int attackDamage;
	float attackRate = 0.5f;     		// The time in seconds between each attack.
	float nextAttack = 0.0f;
	NavMeshAgent nav;							// NavMeshAgent
	NavMeshPath path;
	GameObject gameManager;
	GameObject castle;                          // castle GameObject.
	CastleHealth castleHealth;                  // castle's health.
	MonsterHealth monsterHealth;                // monster's health.
	bool castleInRange;                         // is castle in range to attack
	bool validPath;								// false = there is no valid path to castle
	GameObject buildplace;
	Buildplace buildplaceComponent;

	void Start () {
		// Setting up the references.
		gameManager = GameObject.Find("Game Manager");
		castle = GameObject.Find ("Castle");
		castleHealth = castle.GetComponent <CastleHealth> ();
		monsterHealth = GetComponent<MonsterHealth>();
		if (GetComponent<NavMeshAgent> ()) {
			nav = GetComponent <NavMeshAgent> ();
			// sets navigation target
			nav.SetDestination (castle.transform.position);
		}

		CheckPath ();

		attackDamage = attackDamageBase * (int)gameManager.GetComponent<GameManager>().level;
		//print ("Current Monster Damage: " + attackDamage);
	}
		
	void OnTriggerEnter (Collider other) {
		// if there is no path, start destroying towers.
		if(other.gameObject.GetComponent<Buildplace>()) {
			if (!validPath) {
				buildplace = other.gameObject;
				buildplaceComponent = buildplace.GetComponent<Buildplace> ();
				buildplaceComponent.DestroyTower ();
				CheckPath ();
			}
		}

		// If the entering collider is the player...
		if(other.gameObject == castle) {
			// the player is in range.
			castleInRange = true;
		}
	}
		

	void OnTriggerStay (Collider other) {
		// time to attack, castle in range and monster is alive
		if (Time.time >= nextAttack && castleInRange && castleHealth.currentHealth > 0 && monsterHealth.currentHealth > 0) {
			Attack ();
		}
	}

	void OnTriggerExit (Collider other) {
		// If the exiting collider is the player...
			if(other.gameObject == castle)
			{
				// ... the player is no longer in range.
				castleInRange = false;
			}
	}
		
	void Attack () {
		nextAttack = Time.time + attackRate;
		// if castle is alive
		if(castleHealth.currentHealth > 0) {
			// damage the player
			castleHealth.TakeDamage (attackDamage);
		}
	}

	void CheckPath() {
		path = new NavMeshPath ();
		nav.CalculatePath (castle.transform.position, path);
		//print (path.status);
		validPath = (path.status == NavMeshPathStatus.PathComplete);
	}
}