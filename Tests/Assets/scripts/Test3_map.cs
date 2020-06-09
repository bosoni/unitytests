// https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
using UnityEngine;

public class Test3_map : MonoBehaviour
{
    public GameObject[] prefabs;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = Instantiate(prefabs[0], Camera.main.transform.position, prefabs[0].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            var rm = GameObject.Find("mapScript").GetComponent<RandomMap>();
            for (int q = 0; q < 10; q++)
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
                }

            }
            //Debug.Log("object count = " + rm.objects);
        }

        if (Input.GetKey(KeyCode.Tab))
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;

    }

    void FixedUpdate()
    {
        // näytä infot
        var rm = GameObject.Find("mapScript").GetComponent<RandomMap>();
        var txt = GameObject.Find("UI/infoText").GetComponent<InfoText>();
        string strr = "Object count: " + rm.objects;
        // target
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000.0f)) // tsekataan osuuko mihinkään obuun
        {
            target.transform.position = hit.point;
            strr += "\n" + hit.collider.name + "  dist=" + hit.distance;
        }
        else target.transform.position.Set(1000, 1000, 1000);
        txt.SetText(strr);

    }
}
