using UnityEngine;
using System.Collections;

public class ToinenUkkeli : MonoBehaviour
{
    float xd = 0, ang = 0;
    int puhe = 0;
    float info = 0;
    float delta = 0;
    Vector3 pos;

    void Start()
    {
        // Z=Y eli mitä alempana, sitä lähempänä
        transform.position = new Vector3(transform.position.x, transform.position.y, 0.1f * transform.position.y - Globals.YFix);

        pos = transform.localPosition;
    }

    void Update()
    {
        delta = Time.deltaTime;

        switch (puhe)
        {
            case 2:
                ang += (delta * 4);
                xd = Mathf.Sin(ang) * 0.1f;
                break;

            case 3:
                pos.x -= delta;
                break;

        }

        transform.position = new Vector3(pos.x + xd, transform.position.y, transform.position.z);
    }

    void OnMouseUp()
    {
        if (puhe < 3)
            puhe++;
        info = 5;

    }

    void OnGUI()
    {
        if (info > 0) info -= delta;
        float cx = Screen.width / 2, cy = Screen.height / 2;

        if (info > 0)
            switch (puhe)
            {
                case 1:
                    GUI.Box(new Rect(cx - 200, 70, 400, 50), "Joku juoppo:\nÄäh, hävitin lompshan, olekshä nähnyt mun lompakkoani?");
                    break;
                case 2:
                    GUI.Box(new Rect(cx - 200, 70, 400, 50), "Joku juoppo, raivostuneena:\nKävin vaa kushella ja shit she shaatana hävish!");
                    break;
                case 3:
                    GUI.Box(new Rect(cx - 150, 70, 300, 50), "Joku juoppo:\nHaishta pashka shenkin pashkkaläjä!");
                    break;
            }
    }
}
