using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CollidableMove : MonoBehaviour
{
    Rigidbody rb;

    GameState state;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        state = FindObjectOfType<GameState>();
        if (state == null) throw new MissingReferenceException("No component GameState, this is needed for the global object speed!");
    }

    void FixedUpdate()
    {
        // Multiply by -1 as we want it to move towards the camera
        Vector3 movementVelocity = new Vector3(state.objectMoveSpeed * -1, 0, 0);

        rb.velocity = movementVelocity;
    }
}
