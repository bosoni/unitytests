// https://stackoverflow.com/questions/8465323/unity-fps-rotation-camera
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float mouseSensitivity = 200f;

    // Update is called once per frame
    void Update()
    {
        MoveView();
    }
    private void MoveView()
    {
        transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime);

        float angle;
        Vector3 vec;
        transform.localRotation.ToAngleAxis(out angle, out vec);
        if (angle >= 80)
            angle = 80;

        transform.localRotation = Quaternion.AngleAxis(angle, vec);

    }
}
