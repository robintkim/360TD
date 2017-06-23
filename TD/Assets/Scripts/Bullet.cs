using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	// speed
	public float speed = 10;			// speed
	public int damage;					// damage (set by tower)
	public Transform target;			// target (set by tower)

	// Called every fixed framerate frame.  Used instead of update when dealing with Rigidbody
	void FixedUpdate() {
		// check for target (might be dead)
		if (target) {
			// Fly towards the target
			Vector3 dir = target.position - transform.position;
			GetComponent<Rigidbody> ().velocity = dir.normalized * speed;
		} else {
			// if no target, destroy self
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider co) {
		if (co.GetComponent<Monster> ()) {
			// get for monsterHealth component and damage if not dead
			MonsterHealth monsterHealth = co.GetComponent <MonsterHealth> ();
			if (monsterHealth != null) {
				monsterHealth.TakeDamage (damage, gameObject.transform.position);
			}
			Destroy (gameObject);
		}
	}
}

