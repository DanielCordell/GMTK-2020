using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlController : MonoBehaviour
{
    private int arrayLength = 10;
    private int controlHealthMax = 100;
    public KeyCode[] controlName =  new KeyCode[10] { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P };

    public int[] controlHealthList;

    private List<int> nextRefill = new List<int>();

    public CarMove killdozerMovement;

    private int lastPressedIndex = 10;

    private CarMove.MoveDirection lastDirection;

    // Start is called before the first frame update
    void Start()
    {
        controlHealthList = new int[arrayLength];
        for (int i = 0; i < arrayLength; i++)
        {
            controlHealthList[i] = controlHealthMax;
        } 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var killdozerMoved = false;
        for (var i = 0; i < controlName.Length; ++i)
        {
            if (Input.GetKeyDown(controlName[i])) {
                MoveKilldozer(i);
                killdozerMoved = true;
            }
        }
        //if (!killdozerMoved) StopKilldozer();
    }

    private void MoveKilldozer(int i)
    {
        if (controlHealthList[i] == controlHealthMax)
        {
            controlHealthList[i] = 0;
            lastDirection = i < lastPressedIndex ? CarMove.MoveDirection.LEFT : i > lastPressedIndex ? CarMove.MoveDirection.RIGHT : lastDirection;
            killdozerMovement.UpdateMovement(lastDirection);
            lastPressedIndex = i;
            nextRefill.Add(i);
        }
    }

    private void StopKilldozer()
    {
        killdozerMovement.UpdateMovement(CarMove.MoveDirection.STOP);
    }

    public void RefillKey(int value)
    {
        if (nextRefill.Count > 0)
        {
            controlHealthList[0] = Mathf.Min(controlHealthMax, controlHealthList[0] += value);
            if (controlHealthList[0] == controlHealthMax) nextRefill.RemoveAt(0);
        }
    }
}
