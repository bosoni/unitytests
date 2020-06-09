using UnityEngine;
using System.Collections;

public class KaljaaMenuAction : MonoBehaviour
{
    public string Action = "";
    public Light myLight;
    bool entered = false;

    // Update is called once per frame
    void Update()
    {
        if (entered == false) return;

        switch (Action)
        {
            case "start":
                myLight.color = Color.white;
                break;

        }
    }

    void OnMouseEnter()
    {
        entered = true;
    }

    void OnMouseExit()
    {
        entered = false;
        if(myLight!=null) myLight.color = Color.yellow;
    }

    void OnMouseUp()
    {
        switch (Action)
        {
            case "start":
                Application.LoadLevel(1);
                break;
        }
    }
}
