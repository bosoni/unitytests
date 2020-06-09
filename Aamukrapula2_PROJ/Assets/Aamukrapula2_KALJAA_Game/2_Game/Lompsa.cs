using UnityEngine;
using System.Collections;

public class Lompsa : MonoBehaviour
{
    public GameObject player;
    float info = 0;
    string txt = "";

    void Start()
    {
    }

    void OnMouseUp()
    {
        // pitää laskea onko pelaaja tarpeeks lähellä tätä lompsaa.
        Vector3 tmppos = new Vector3(player.transform.position.x, player.transform.position.y - Globals.YFix, player.transform.position.z);

        float len = Globals.CalcDist2D(tmppos, transform.position);
        if (len > 1f)
        {
            txt = "Tuolla kaukana taitaa olla jotain...";
            info = 4;
            return;
        }

        if (Globals.OtettuLompsa == false)
        {
            GetComponent<Renderer>().enabled = false;
            Ovi.Reset();
            Globals.OtettuLompsa = true;
            info = 4;
            txt = "Mikä tuuri, lompakko täynnä rahaa.";
        }
    }

    void OnGUI()
    {
        float cx = Screen.width / 2, cy = Screen.height / 2;
        if (info > 0)
        {
            info -= Time.deltaTime;
            GUI.Box(new Rect(cx - 200, 20, 400, 25), txt);
        }
    }
}
