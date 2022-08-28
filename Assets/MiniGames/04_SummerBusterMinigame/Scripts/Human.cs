using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Human : MonoBehaviour
{
    public static List<Vector3> slots = new List<Vector3>();

    protected const float RINGHEIGHT = 1.75f;

    protected void AddSlots(Vector3 pos)
    {
        slots.Clear();

        for (int i = 0; i < 3; i++)
        {
            slots.Add(new Vector3(pos.x, 1 + i * RINGHEIGHT, pos.z));
        }
    }

   
}
