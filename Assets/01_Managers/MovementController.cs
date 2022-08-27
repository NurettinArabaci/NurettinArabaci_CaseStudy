using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovementController : MonoBehaviour
{
    protected Transform mT;
    protected Vector3 gap;
    protected Vector3 initPose;

    protected virtual void Awake()
    {
        mT = transform;
        initPose = mT.position;
    }

    protected virtual void OnMouseDown()
    {
        gap = Input.mousePosition - Camera.main.WorldToScreenPoint(mT.position);

    }

    protected virtual void OnMouseDrag()
    {
        Vector3 smooth = Camera.main.ScreenToWorldPoint(Input.mousePosition - gap);
        mT.position = Vector3.MoveTowards(mT.position, smooth, 1f);

        mT.position = ClampPose();

    }

    protected virtual Vector3 ClampPose()
    {
        return new Vector3(Mathf.Clamp(mT.position.x, -8, 6), 0.1f, Mathf.Clamp(mT.position.z, -10, 4));
    }

    protected virtual void OnMouseUp()
    {
        mT.DOMove(initPose, 0.3f);
    }
}
