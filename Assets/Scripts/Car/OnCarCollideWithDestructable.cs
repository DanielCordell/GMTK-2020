using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OnCarCollideWithDestructable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collidable"))
        {
            ObjectSwapOnCollide objectSwap = other.gameObject.GetComponent<ObjectSwapOnCollide>();
            if (objectSwap != null && objectSwap.newObject != null)
            {
                GameObject newObj = Instantiate(objectSwap.newObject, other.transform.position, other.transform.rotation);
                Rigidbody oldRB = other.GetComponent<Rigidbody>();
                if (oldRB != null)
                    foreach (Rigidbody rb in newObj.GetComponentsInChildren<Rigidbody>())
                    {

                        rb.AddExplosionForce(2000, transform.position + Vector3.left, 10);
                    }
            }
            Destroy(other.gameObject);
        }
    }
}
