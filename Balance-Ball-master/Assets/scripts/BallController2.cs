using UnityEngine;

public class BallController2 : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 500f;
    public Transform cameraTransform;
    public bool GameOver = false;

    private Rigidbody rb;
    private Rigidbody ground;
    
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        // Rotation
        if (horizontal != 0f)
        {
            transform.Rotate(Vector3.up, horizontal * moveSpeed * Time.deltaTime);
            cameraTransform.Rotate(Vector3.up, horizontal * moveSpeed * Time.deltaTime);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // Check if grounded
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
