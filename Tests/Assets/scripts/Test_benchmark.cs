// https://docs.unity3d.com/ScriptReference/Physics.Raycast.html

/*
 * benchmark
 * enter lisää obuja
 * space laittaa obut pyörimään
 * L varjot päälle ja pois
 * 
 * */
using System.Collections.Generic;
using UnityEngine;

public class Test_benchmark : MonoBehaviour
{
    public GameObject[] prefabs;
    GameObject target;
    List<GameObject> objs = new List<GameObject>();
    bool rotating = false;

    // Update is called once per frame
    void Update()
    {
        var rm = GameObject.Find("mapScript").GetComponent<RandomMap>();
        if (Input.GetKey(KeyCode.Return))
        {
            for (int q = 0; q < 100; q++)
            {
                float S = 100;
                float x = Random.Range(-S, S);
                float z = Random.Range(-S, S);
                float y = rm.GetY(x, z);
                if (y > 0) // ei veden alle
                {
                    var go = rm.AddToMap(x, y, z);

                    if (Random.Range(0, 10) < 5)
                        rm.RandomMaterial(go);

                    objs.Add(go);
                }

            }
            //Debug.Log("object count = " + rm.objects);
        }

        if (Input.GetKey(KeyCode.L))
        {
            var l = GameObject.Find("Directional Light").GetComponent<Light>();
            if (l.shadows == LightShadows.None)
                l.shadows = LightShadows.Soft;
            else
                l.shadows = LightShadows.None;
        }

        if (Input.GetKey(KeyCode.Tab))
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;

        // uudet obut pyörimään
        if (Input.GetKey(KeyCode.Space))
            rotating = !rotating;

        if (rotating)
            foreach (var go in objs)
            {
                go.transform.Rotate(new Vector3(0, Time.deltaTime * 100, 0));
            }

        // näytä infot
        var txt = GameObject.Find("UI/infoText").GetComponent<InfoText>();
        string strr = "Object count: " + rm.objects;
        if (rotating) strr += "\nrotating";
        txt.SetText(strr);

    }
}
