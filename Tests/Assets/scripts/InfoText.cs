using UnityEngine;
using UnityEngine.UI;

public class InfoText : MonoBehaviour
{
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }
    public void SetText(string newText)
    {
        text.text = newText;
    }

}
