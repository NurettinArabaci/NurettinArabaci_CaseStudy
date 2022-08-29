using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D;

public class WaterVacuum : MovementController
{
    P3dChannelCounter counter;

    bool startGame=false;

    protected override void Awake()
    {
        counter = GetComponent<P3dChannelCounter>();
        
        base.Awake();
        

        

        moveHeight = 7;
        maxZ = 6;
        minX = -5;
        maxX = 3;

        EventManager.OnChangeVacuum += OnChangeVacuum;

    }
    protected override void OnMouseDown()
    {
        startGame = true;
        base.OnMouseDown();
    }

    protected override void OnMouseDrag()
    {
        if(!startGame)return; 
        base.OnMouseDrag();
    }

    protected override void OnMouseUp() { }

    private void Update()
    {
        if (!startGame) return;

        if (counter.RatioA < 0.002f)
        {
            startGame = false;
            NAEngine.MoveBySpeed(mT, Vector3.up * 10, 100);
            EventManager.Fire_OnCoinUpdate(50);
            EventManager.Fire_OnLevelCompleted();

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
