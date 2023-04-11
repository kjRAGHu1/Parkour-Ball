using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target ;
    public float distance = 10.0f;
    public float height = 5.0f;
    public float rotationDamping = 10.0f;

    void LateUpdate () {

        float desiredAngle = target.eulerAngles.y;
        float desiredHeight = target.position.y + height;
        float currentAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        currentAngle = Mathf.LerpAngle(currentAngle, desiredAngle, rotationDamping * Time.deltaTime);
        currentHeight = Mathf.Lerp(currentHeight, desiredHeight, rotationDamping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0, currentAngle, 0);

        Vector3 desiredPosition = target.position - (currentRotation * Vector3.forward * distance);
        desiredPosition.y = currentHeight;

        transform.position = desiredPosition;
        transform.LookAt(target);
    }
}
