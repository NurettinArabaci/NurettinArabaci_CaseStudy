using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D;

public class WaterVacuum : MovementController
{
    P3dChannelCounter counter;

    static bool cleanComplete;

    protected override void Awake()
    {
        base.Awake();
        cleanComplete = false;

        counter = GetComponent<P3dChannelCounter>();

        moveHeight = 7;
        maxZ = 6;
        minX = -5;
        maxX = 3;

        EventManager.OnChangeVacuum += OnChangeVacuum;

    }
    protected override void OnMouseDrag()
    {
        if(cleanComplete)return; 
        base.OnMouseDrag();
    }

    protected override void OnMouseUp() { }

    private void Update()
    {
        if (counter.RatioA <= 0 || cleanComplete) return;

        else if (counter.RatioA < 0.002f)
        {
            NAEngine.MoveBySpeed(mT, Vector3.up * 7, 100);
            EventManager.Fire_OnLevelCompleted();
            cleanComplete = true;

        }
    }

    void OnChangeVacuum()
    {
       
        NAEngine.MoveBySpeed(mT, Vector3.up*7, 100);

    }

    private void OnDisable()
    {
        EventManager.OnChangeVacuum -= OnChangeVacuum;

    }


}
