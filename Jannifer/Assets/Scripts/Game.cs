using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
	static public int taken = 0; // montako lahjaa otettu

	public float areaX, areaZ;
	public GameObject present;
	public GameObject monster;
	

	// Use this for initialization
	void Start ()
	{
	
		for (int q=0; q<20; q++) {
			Vector3 pos = new Vector3 (Random.Range (-areaX, areaX), -1, Random.Range (-areaZ, areaZ));
			Quaternion rot = Quaternion.identity;
			
			if (q < 10)
				Instantiate (monster, pos, rot);
			else 
				Instantiate (present, pos, rot);
		}
	
	}
	
}
