// https://docs.unity3d.com/ScriptReference/Collider.Raycast.html
// http://gyanendushekhar.com/2018/09/16/change-material-and-its-properties-at-runtime-unity-tutorial/

using UnityEngine;

public class RandomMap : MonoBehaviour
{
    public GameObject[] prefabs;
    public int objects = 0;
    Collider coll;

    void Start()
    {
        coll = GameObject.Find("ground2/Plane").GetComponent<Collider>();

        for (int q = 0; q < 100; q++)
        {
            float S = 100;
            float x = Random.Range(-S, S);
            float z = Random.Range(-S, S);
            float y = GetY(x, z);
            if (y < 0.1f) continue; // ei veden alle

            AddToMap(x, y, z);
        }
    }

    public GameObject AddToMap(float x, float y, float z)
    {
        var pos = new Vector3(x, y, z);

        var r = Random.Range(0, prefabs.Length);
        var scale = new Vector3(1, 1, 1);
        if (r == 0) // sieni
            if (Random.Range(0, 10) < 3)
            {
                scale = new Vector3(0.2f, 0.2f, 0.2f); // pieni sieni
            }
        var g = Instantiate(prefabs[r], pos, prefabs[r].transform.rotation);
        g.transform.localScale = scale;
        objects++;

        return g;
    }

    public void RandomMaterial(GameObject g)
    {
        //MeshRenderer meshRenderer = g.GetComponent<MeshRenderer>();
        //GetComponent<MeshRenderer>().material.mainTexture = SampleTexture;

        MeshRenderer m;
        if (g.TryGetComponent<MeshRenderer>(out m))
        {
            for(int q=0; q<m.materials.Length; q++)
                m.materials[q].color = new Color(Random.Range(0f, 1), Random.Range(0f, 1), Random.Range(0f, 1));
        }

    }

    public float GetY(float x, float z)
    {
        RaycastHit hit;
        Ray ray = new Ray(new Vector3(x, 1000, z), Vector3.down);
        if (coll.Raycast(ray, out hit, 1000.0f))
        {
            return hit.point.y;
        }
        return 0;
    }

}
