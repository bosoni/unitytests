using UnityEngine;
using System.Collections;

public class Ovi : MonoBehaviour
{
    static float info = 0;

    public static void Reset()
    {
        info = 0;
    }

    void OnMouseUp()
    {
        info = 5;
    }

    void OnGUI()
    {
        float cx = Screen.width / 2, cy = Screen.height / 2;

        if (info > 0)
        {
            info -= Time.deltaTime;
            if (Globals.OtettuLompsa == false)
                GUI.Box(new Rect(cx - 150, 40, 300, 25), "Ei sulla ole yhtään rahaa joten et mene sisälle.\n");
            else
            {
                info = 5;//lopputeksti ei häviä ikinä
                GUI.Box(new Rect(cx - 150, cy - 20, 300, 50), "Menit sisälle baariin ja vedit kännit.\n\nPeli läpi, pisteesi 100/100\n");
                Globals.PeliLapi = true;
            }

        }
    }

}
