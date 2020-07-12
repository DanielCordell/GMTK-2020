using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlController : MonoBehaviour
{
    private int arrayLength = 10;
    private int valueMax = 100;
    public KeyCode[] controlName =  new KeyCode[10] { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P };

    public int[] controlList;

    private List<int> nextRefill = new List<int>();

    public GameObject Killdozer;

    private int lastPressedIndex = 10;

    // Start is called before the first frame update
    void Start()
    {
        controlList = new int[arrayLength];
        for (int i = 0; i < arrayLength; i++)
        {
            controlList[i] = valueMax;
        } 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(controlName[0])) MoveKilldozer(0);
        if (Input.GetKeyDown(controlName[1])) MoveKilldozer(1);
        if (Input.GetKeyDown(controlName[2])) MoveKilldozer(2);
        if (Input.GetKeyDown(controlName[3])) MoveKilldozer(3);
        if (Input.GetKeyDown(controlName[4])) MoveKilldozer(4);
        if (Input.GetKeyDown(controlName[5])) MoveKilldozer(5);
        if (Input.GetKeyDown(controlName[6])) MoveKilldozer(6);
        if (Input.GetKeyDown(controlName[7])) MoveKilldozer(7);
        if (Input.GetKeyDown(controlName[8])) MoveKilldozer(8);
        if (Input.GetKeyDown(controlName[9])) MoveKilldozer(9);

    }

    private void MoveKilldozer(int i)
    {
        if (controlList[i] == valueMax)
        {
            {
                controlList[i] = 0;
                if (i < lastPressedIndex) print("move killdozer left");
                else print("move killdozer right");
                lastPressedIndex = i;
                nextRefill.Add(i);
            }
        }
    }

    public void RefillKey(int value)
    {
        if (nextRefill != null)
        {
            controlList[0] = Mathf.Min(valueMax, controlList[0] += value);
            if (controlList[0] == valueMax) nextRefill.RemoveAt(0);
        }
    }
}
