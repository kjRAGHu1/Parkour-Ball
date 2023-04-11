using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float movSpeed = 10f;
    public float jumpForce = 5f;
    public Transform camTransform;


    private Rigidbody rb;
    private bool isGrounded = true;
    private float mouseX;
    private float mouseY;
    private float sensitivity = 50f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move the ball based on input
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * movSpeed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + movement);

        // Jump if spacebar is pressed and ball is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Check if ball is grounded
        if (Mathf.Abs(rb.velocity.y) < 0.001f && !isGrounded)
        {
            isGrounded = true;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        // Check if ball is grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void LateUpdate()
    {
        // Rotate the camera based on mouse input
        mouseX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -60f, 60f);
        camTransform.rotation = Quaternion.Euler(mouseY, mouseX, 0f);

        // Follow the ball with the camera
        camTransform.position = transform.position - camTransform.forward * 5f + new Vector3(0f, 3f, 0f);
    }
}
