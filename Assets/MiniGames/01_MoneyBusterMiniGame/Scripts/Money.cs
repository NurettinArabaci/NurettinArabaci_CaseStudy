using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Money : MovementController
{
    bool isFinish = false;

    protected override Vector3 ClampPose()
    {
        return new Vector3(Mathf.Clamp(mT.position.x, -6, 6), 0f, Mathf.Clamp(mT.position.z, -5, 15));
    }

    protected override void OnMouseUp()
    {
        if (!isFinish)
        {
            base.OnMouseUp();
        }
        
    }

    protected override void OnMouseDrag()
    {
        if (!isFinish)
        {
            base.OnMouseDrag();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MoneyHolder"))
        {
            print("MoneyHolder");

            other.GetComponent<Animator>().SetTrigger("MoneyStack");
           // Delay.WaitForMe(() => other.GetComponent<Animator>().SetTrigger("MoneyStack"), 0.3f);

            //other.transform.DOShakePosition(0.3f, Vector3.up);

            MoveAnimation(other.transform,12);
        }

        else if (other.CompareTag("PaperShredder"))
        {
            other.GetComponent<Animator>().SetTrigger("MoneyShredStart");

            mT.parent = other.transform;
            other.transform.DOShakePosition(1.2f, Vector3.up);

            MoveAnimation(other.transform,14);

        }
    }

    void MoveAnimation(Transform tr, float z)
    {
        isFinish = true;
        mT.DOMoveX(tr.position.x, 0.2f);
        mT.DORotate(Vector3.up * (-90), 0.3f);
        Delay.WaitForMe(() => mT.DOMoveZ(z, 0.7f), 0.3f);
    }

}
