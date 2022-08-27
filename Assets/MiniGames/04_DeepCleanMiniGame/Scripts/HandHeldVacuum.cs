using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHeldVacuum : MovementController
{
    Vector3 lookPose;

    protected override void Awake()
    {
        base.Awake();

        lookPose = new Vector3(-5f, 0f, 4f);

        moveHeight = 3f;
        minZ = -9f;
        maxX = -1f;

    }

    protected override void OnMouseDrag()
    {
        base.OnMouseDrag();
        mT.LookAt(lookPose);
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chips"))
        {
            Chips chips = other.GetComponent<Chips>();

            chips.OnClean();
        }
    }
}
