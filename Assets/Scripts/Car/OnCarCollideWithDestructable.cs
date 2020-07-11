using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCarCollideWithDestructable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destructable"))
        {
            Destroy(other.gameObject);
        }
    }
}
