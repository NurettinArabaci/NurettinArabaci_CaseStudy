using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D;

public class WaterVacuum : MovementController
{
    P3dChannelCounter counter;

    bool cleanComplete = false;

    protected override void Awake()
    {
        base.Awake();

        counter = GetComponent<P3dChannelCounter>();

        moveHeight = 7;
        maxZ = 6;
        minX = -5;
        maxX = 3;

    }

    protected override void OnMouseUp()
    {
        //do nothing
    }

    private void FixedUpdate()
    {
        if (counter.RatioA <= 0 || cleanComplete) return;

        else if (counter.RatioA < 0.001f)
        {
            Debug.Log("LevelCompleted");
            cleanComplete = true;
            
        }
    }
}
