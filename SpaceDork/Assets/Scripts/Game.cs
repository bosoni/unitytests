using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour
{
	public GameObject asteroid, playAgain;
	public static bool alive = true;
	
	public static int score;
	
	// Use this for initialization
	void Start ()
	{
		score = 0;
		alive = true;
		playAgain.transform.position = new Vector3 (40, 30, 50);
		
		StartCoroutine (CreateAsteroids ());
	}
	
	IEnumerator CreateAsteroids ()
	{
		while (alive) {
			Vector3 pos = new Vector3 (Random.Range (-40, 40), 0, 32);
			Quaternion rot = Quaternion.identity;
			Instantiate (asteroid, pos, rot);
			yield return new WaitForSeconds (0.8f);
		}
	}

	void Update ()
	{
		if (alive == false)
			playAgain.transform.position = new Vector3 (0, 30, 0);
			
	}
			
}
