using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarMove : MonoBehaviour
{
    Rigidbody rigidBody;

    public float force;

    public float maxAngleTurn;
    public float rotationSpeed;
    float currentAngleTurn;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        currentAngleTurn = 0;
    }

    void FixedUpdate()
    {
        float forwardAxis = Input.GetAxis("Horizontal");

        if (forwardAxis != 0)
        {
            rigidBody.AddForce(Vector3.back * forwardAxis * force);

            currentAngleTurn = Mathf.Lerp(currentAngleTurn, maxAngleTurn * Mathf.Sign(forwardAxis), Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.LookRotation(new Vector3(Mathf.Sin(currentAngleTurn * Mathf.Deg2Rad), 0, Mathf.Cos(currentAngleTurn * Mathf.Deg2Rad)), transform.up);
        }
        else
        {
            currentAngleTurn = Mathf.Lerp(currentAngleTurn, 0, Time.deltaTime * rotationSpeed * 0.5f);
            transform.rotation = Quaternion.LookRotation(new Vector3(Mathf.Sin(currentAngleTurn * Mathf.Deg2Rad), 0, Mathf.Cos(currentAngleTurn * Mathf.Deg2Rad)), transform.up);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<GameState>().ChangeSpeedTemporarily(2, 2f);
        }
    }
}
