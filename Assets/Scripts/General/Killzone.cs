using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    public string[] tagsToKill;
    private void OnCollisionEnter(Collision collision)
    {
        // Ensure we destroy our objects once they go off screen. Only for matching tags
        if (tagsToKill.Any(tag => collision.gameObject.CompareTag(tag)))
        {
            Destroy(collision.gameObject);
        }
    }
}
