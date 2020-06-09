// https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
using UnityEngine;

public class Test2_shoot : MonoBehaviour
{
    public GameObject[] prefabs;
    Rigidbody rigidBody;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = Instantiate(prefabs[1], Camera.main.transform.position, prefabs[1].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;

    }

    void FixedUpdate()
    {
        // target
        RaycastHit hit;
        bool hitt = false;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000.0f)) // tsekataan osuuko mihinkään obuun
        {
            target.transform.position = hit.point;
            hitt = true;
        }
        else target.transform.position.Set(1000, 1000, 1000);
        //---------------

        // heitä kivi
        if (Input.GetMouseButtonDown(0))
        {
            var g = Instantiate(prefabs[0], Camera.main.transform.position, prefabs[0].transform.rotation);
            g.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

            Vector3 dir;

            if (Cursor.lockState == CursorLockMode.Locked)
                dir = Camera.main.transform.TransformDirection(Vector3.forward);
            else
            {
                if (hitt)
                {
                    dir = target.transform.position - Camera.main.transform.position;
                    dir.Normalize();
                }
                else
                    dir = Camera.main.transform.TransformDirection(Vector3.forward);
            }

            rigidBody = g.GetComponent<Rigidbody>();
            rigidBody.position += dir * 1.1f;
            rigidBody.AddForce(dir * 500);
        }


    }
}
