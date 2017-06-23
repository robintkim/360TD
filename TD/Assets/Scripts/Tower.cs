using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
	
	public GameObject bulletPrefab;

	int damage = 25;                  		// damage
	float fireRate = 1.0f;					// time between shots
	float nextFire = 0.0f;                  // timer to keep track of firing
	ParticleSystem gunParticles;            // Reference to the particle system.
	AudioSource gunAudio;                   // Reference to the audio source.

	void Awake()
	{
		// Set up the references
		gunParticles = GetComponentInChildren<ParticleSystem> ();
		gunAudio = GetComponent<AudioSource> ();
	}
		
	void OnTriggerStay(Collider co) {
		// Check for monster and shoot
		if (co.GetComponent<Monster> () && !co.GetComponent<MonsterHealth>().IsDead()) {
			// look at monster
			transform.LookAt(new Vector3(co.transform.position.x, transform.position.y, co.transform.position.z));
			// check timer to fire

			if (Time.time > nextFire) {
				Shoot (co.gameObject);
			}
		}
	}
		
	void Shoot(GameObject obj) {

		nextFire = Time.time + fireRate;

		GameObject g = (GameObject)Instantiate (bulletPrefab, transform.position + new Vector3 ((float)0, (float)1.25, (float)0), Quaternion.identity);
		g.GetComponent<Bullet> ().target = obj.transform;
		g.GetComponent<Bullet> ().damage = damage;

		// Play the gun shot audioclip
		gunAudio.Play ();

		// Stop the particles from playing if they were, then start the particles.
		gunParticles.Stop ();
		gunParticles.Play ();

	}
}
