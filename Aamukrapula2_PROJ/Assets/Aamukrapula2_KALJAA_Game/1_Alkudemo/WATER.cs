using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WATER : MonoBehaviour
{
    float s = 0.5f;
    float info = 10;
    float delta = 0;
    Vector3 pos;

    private void Start()
    {
        pos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        delta = Time.deltaTime;
        s += delta;
        Vector3 newpos = new Vector3(pos.x + Mathf.Sin(s) * 10, pos.y, pos.z);
        transform.localPosition = newpos;
    }

    void OnGUI()
    {
        if (info > 0)
        {
            info -= delta;

            float cx = Screen.width / 2, cy = Screen.height / 2;
            GUI.Box(new Rect(cx - 200, 50, 400, 50), "Heräsit meren rannalta krapulassa. \nKaljaa mielesi tekevi, mutta olet persaukinen.");

        }
        else
        {
            GUI.Box(new Rect(20, 0, 80, 25), "Loading...");
            SceneManager.LoadScene(2);
        }
    }
}
