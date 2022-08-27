using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : Human
{
    Transform mT;
    Vector3 mPos;

  
    private void Awake()
    {
        mT = transform;
        mPos = mT.position;

        AddSlots(mPos);

    }

    





}
