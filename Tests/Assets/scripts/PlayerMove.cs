//https://stackoverflow.com/questions/8465323/unity-fps-rotation-camera
//https://answers.unity.com/questions/196381/how-do-i-check-if-my-rigidbody-player-is-grounded.html
using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    [Header("player Movement")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] public float mouseSensitivity = 200f;

    Collider coll;
    Rigidbody rigidBody;
    float distToGround;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        // get the distance to ground
        distToGround = coll.bounds.extents.y;
    }

    bool IsGrounded(bool capsule = false)
    {
        /* --TODO FIX  en saa toimii
        if (capsule)
            return Physics.CheckCapsule( coll.bounds.center,
                new Vector3(coll.bounds.center.x, -0.5f, coll.bounds.center.z), 
                0.5f);
        */
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);

    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded(true))
        {
            rigidBody.AddForce(0, 500, 0);
            //Debug.Log("space ");
        }
    }

    void Update()
    {
        Move();
        if (rigidBody.position.y < -1)
            rigidBody.position = new Vector3(0, 5, 0);
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime);
    }
}
