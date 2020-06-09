using UnityEngine;
using System.Collections;

public class LightAnim : MonoBehaviour
{
    public Light myLight = null;
    float w = 0;

    // Update is called once per frame
    void Update()
    {
        w += (Time.deltaTime * 2);
        if (myLight != null) myLight.color = new Color(Mathf.Sin(w), GetComponent<Light>().color.g, GetComponent<Light>().color.b);

    }
}
