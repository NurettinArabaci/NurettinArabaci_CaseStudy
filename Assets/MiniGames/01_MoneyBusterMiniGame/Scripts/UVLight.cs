using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class UVLight : MovementController
{
 
    [SerializeField] private GameObject child;

    protected override void OnMouseDown()
    {
        base.OnMouseDown();

        child.SetActive(true);

    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();

        child.SetActive(false);       
    }

}
