using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotate : MonoBehaviour
{
    // Todo I could make this relative to the movement speed but eh
    public Vector3 rotationDirection;
    public float rotationBaseSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(rotationDirection, rotationBaseSpeed * Time.deltaTime);
    }
}
