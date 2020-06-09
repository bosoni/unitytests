using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour
{
	public Material[] materials;
	public float speed = 0.3f;
	public GameObject player, death, playAgain;

	private float changeInterval = 0.33f;
	
	void Start ()
	{
		playAgain.GetComponent<Renderer> ().enabled = false;
		Game.taken = 0;
	}
	
	void Update ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		if (moveHorizontal != 0 || moveVertical != 0) {
			// ukon asento riippuen mihin suuntaan se kulkee
			if ((moveHorizontal > 0 && player.transform.localScale.x > 0) || (moveHorizontal < 0 && player.transform.localScale.x < 0))
				player.transform.localScale = new Vector3 (-player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);
			
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);	
			transform.position += movement * speed;
			
			var index = Mathf.FloorToInt (Time.time / changeInterval);
			index = index % materials.Length;
			player.GetComponent<Renderer> ().material = materials [index];
			
		}
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Present") {
			Game.taken++;
			if (Game.taken == 10) {
				Application.LoadLevel (2);
			}

		}
		 
		// die
		if (other.tag == "Monster") {
			Destroy (gameObject);		
			Instantiate (death, other.transform.position, other.transform.rotation);
			playAgain.GetComponent<Renderer> ().enabled = true;
		}
	
		Destroy (other.gameObject);
	}	
	
}
