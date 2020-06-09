using UnityEngine;
using System.Collections;

public class Alku : MonoBehaviour
{
	void OnMouseUp ()
	{
		Game.alive = true;
		Application.LoadLevel (1);
	}	
}
