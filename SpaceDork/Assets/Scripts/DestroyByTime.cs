using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour
{
	public float lifetime = 5;
	
	void Start ()
	{
		Destroy (gameObject, lifetime);
	}
}
