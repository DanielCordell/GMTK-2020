using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollideWithCollidable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collidable"))
        {
            Destroy(other.gameObject);
        }
    }
}
