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
    MoveDirection currentMoveDirection;

    public enum MoveDirection
    {
        LEFT = -1,
        STOP = 0,
        RIGHT = 1
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        currentAngleTurn = 0;
        currentMoveDirection = MoveDirection.STOP;
    }

    public void UpdateMovement(MoveDirection direction)
    {
        currentMoveDirection = direction;
    }

    void FixedUpdate()
    {
        if (currentMoveDirection != 0)
        {
            int moveDirectionValue = (int) currentMoveDirection;
            rigidBody.AddForce(Vector3.back * Mathf.Sign(moveDirectionValue) * force);
            currentAngleTurn = Mathf.Lerp(currentAngleTurn, maxAngleTurn * Mathf.Sign(moveDirectionValue), Time.deltaTime * rotationSpeed);
        }
        else
        {
            currentAngleTurn = Mathf.Lerp(currentAngleTurn, 0, Time.deltaTime * rotationSpeed * 0.5f);
        }
        transform.rotation = Quaternion.LookRotation(new Vector3(Mathf.Sin(currentAngleTurn * Mathf.Deg2Rad), 0, Mathf.Cos(currentAngleTurn * Mathf.Deg2Rad)), transform.up);
    }
}
