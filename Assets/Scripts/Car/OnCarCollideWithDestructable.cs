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
            CollidableObjectMetadata objectMetadata = other.gameObject.GetComponent<CollidableObjectMetadata>();
            if (objectMetadata != null)
            {

                if (objectMetadata.objectSwappedToOnCollide != null)
                {
                    GameObject newObj = Instantiate(objectMetadata.objectSwappedToOnCollide, other.transform.position, other.transform.rotation);
                    Rigidbody oldRB = other.GetComponent<Rigidbody>();
                    if (oldRB != null)
                        foreach (Rigidbody rb in newObj.GetComponentsInChildren<Rigidbody>())
                        {
                            rb.AddExplosionForce(2000, transform.position + Vector3.left, 10);
                        }
                }
                if (objectMetadata.keyRefilAmountOnHit != 0)
                {
                    ControlController cc = FindObjectOfType<ControlController>();
                    if (cc != null) cc.RefillKey(objectMetadata.keyRefilAmountOnHit);
                }
            }
            Destroy(other.gameObject);
        }
    }
}
