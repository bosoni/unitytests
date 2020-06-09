using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public Text scoreText;
	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary") {
			return;
		}
		
		Instantiate (explosion, transform.position, transform.rotation);
		
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			Game.alive = false;
		}
		
		Game.score++;
		
		Destroy (other.gameObject);
		Destroy (gameObject);
	}

	void Update ()
	{
		scoreText.text = "Score: " + Game.score.ToString ();
	}
			
}
