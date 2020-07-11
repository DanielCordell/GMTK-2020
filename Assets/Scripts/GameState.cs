using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState: MonoBehaviour
{
    // Game Object Speed
    public float objectMoveSpeed;
    private float tempSpeedBuffer = 0;
    private Coroutine tempSpeedChangeCoroutine = null;

    public float GetMoveSpeed()
    {
        return objectMoveSpeed;
    }

    // Temporary speed change (boosts/slow pads)
    public void ChangeSpeedTemporarily(float newSpeed, float time)
    {
        // If starting another temp speed change, stop the previous one and undo the existing speed change.
        if (tempSpeedChangeCoroutine != null)
        {
            objectMoveSpeed = tempSpeedBuffer;
            StopCoroutine(tempSpeedChangeCoroutine);
        }
        tempSpeedChangeCoroutine = StartCoroutine(ChangeSpeedTemporarily_(newSpeed, time));
    }

    // Coroutine to handle the temp speed change.
    private IEnumerator ChangeSpeedTemporarily_(float newSpeed, float time)
    {
        tempSpeedBuffer = objectMoveSpeed;
        objectMoveSpeed = newSpeed;
        yield return new WaitForSeconds(time);
        objectMoveSpeed = tempSpeedBuffer;
        yield return null;
    }

    // Permenant speed change
    public void ChangeSpeed(float newSpeed)
    {
        objectMoveSpeed = newSpeed;
        tempSpeedBuffer = newSpeed;
    }

}
