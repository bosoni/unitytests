/*
 *
 *  X: normaali x
 *  Y: alasp�in -
 *  Z: miinukseen, tulee l�hemm�s
 *  
 * joten voidaan laittaa Z=Y ett� saa zbufferin oikein.
 * 
*/

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public GameObject player;
    Vector3 pos, newpos, dir;
    float lastDist = 0;

    // Use this for initialization
    void Start()
    {
        // Z=Y eli mit� alempana, sit� l�hemp�n�
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0.1f * player.transform.position.y - Globals.YFix);
        pos = newpos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(pos, pos + (dir * 10));

        // laske v�limatka ukon paikan ja uuden paikan v�lill�
        float dist = Globals.CalcDist2D(pos, newpos);
        if (dist <= lastDist) // tarkistus jos ukko k�veli paikkansa ohi, niin ei jatka k�velemist�
        {
            player.transform.Translate(dir * (Time.deltaTime * 30), Space.World);
            // Z=Y eli mit� alempana, sit� l�hemp�n�
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0.1f * player.transform.position.y - Globals.YFix);
            pos = player.transform.position;

            lastDist = dist;
        }
    }

    void OnMouseUp()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        newpos = ray.origin + ray.direction * 2;
        newpos.y += Globals.YFix; // jalkoihin (koska plane:ssa pivot point on keskell�)

        // laske suunta
        dir = newpos - pos;
        dir = dir.normalized * 0.1f;

        lastDist = Globals.CalcDist2D(pos, newpos);

        // ukon asento riippuen mihin suuntaan se kulkee
        if ((dir.x < 0 && player.transform.localScale.x > 0) || (dir.x > 0 && player.transform.localScale.x < 0))
            player.transform.localScale = new Vector3(-player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);

    }

}
