using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    float startTime;
    float shrinkTime;
    public float timeTillShrinkStart;
    public float shrinkSpeed;

    Transform[] objectsToShrink;

    float scale = 0.9f;

    void Start()
    {
        startTime = Time.time;
        shrinkTime = startTime + timeTillShrinkStart;
        objectsToShrink = GetComponentsInChildren<Rigidbody>().Select(rb => rb.transform).ToArray();
        
        // If there are no gameObjects to destroy, just sudoku.
        if (objectsToShrink.Length == 0) Destroy(gameObject);
    }

    void Update()
    {
        if (Time.time >= shrinkTime)
        {
            if (objectsToShrink.All(t => t.localScale.magnitude <= 0.01)) Destroy(gameObject);
            else foreach (Transform t in objectsToShrink)
            {
                t.localScale *= scale;
            }
        }
    }
}
