using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	
	public float accelerationForce = 10f;
	public float rotationForce = 3f;
	
	void FixedUpdate ()
	{
		float rotation = Input.GetAxis ("Horizontal");
		float acceleration = Input.GetAxis ("Vertical");
		GetComponent<Rigidbody> ().AddTorque (0, rotation * rotationForce, 0);
		GetComponent<Rigidbody> ().AddForce (transform.up * acceleration * accelerationForce);

	
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			//audio.Play ();
		}
		
	}
}
