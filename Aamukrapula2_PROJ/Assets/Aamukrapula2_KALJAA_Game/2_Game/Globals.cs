using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour
{
    public Light myLight = null;
    public GameObject player;
    public static bool OtettuLompsa = false;
    public static bool PeliLapi = false;
    public static float YFix = 1;

    void Update()
    {
        if (PeliLapi)
        {
            player.GetComponent<Renderer>().enabled = false;
            myLight.color = myLight.color * 0.9f;
        }
    }


    public static float CalcDist2D(Vector3 v1, Vector3 v2)
    {
        v1.z = v2.z = 0;
        return Vector3.Distance(v1, v2);
    }

}
