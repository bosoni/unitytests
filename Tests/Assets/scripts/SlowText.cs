using UnityEngine;
using UnityEngine.UI;

public class SlowText : MonoBehaviour
{
    string txt = "unity 2019 testing. vittulan jorma sanoi moro.";
    float pos = 0;

    // Update is called once per frame
    void Update()
    {
        pos += Time.deltaTime * 10;
        if (pos >= txt.Length)
            pos = 0;

        GetComponent<Text>().text = txt.Substring(0, (int)pos);
    }

    public void SetText(string newText)
    {
        txt = newText;
    }

}
