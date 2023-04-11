using UnityEngine;

public class BallPlayer : MonoBehaviour
{
    private Vector3 initialPosition; // the initial position of the ball
    
    void Start()
    {
        initialPosition = transform.position; // save the initial position of the ball
    }

    void Update()
    {
        if (transform.position.y < 0) // if the ball falls below the y axis
        {
            Respawn(); // respawn the ball at its initial position
        }
    }

    void Respawn()
    {
        transform.position = initialPosition; // set the position of the ball to its initial position
        GetComponent<Rigidbody>().velocity = Vector3.zero; // reset the velocity of the ball
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // reset the angular velocity of the ball
    }
}
