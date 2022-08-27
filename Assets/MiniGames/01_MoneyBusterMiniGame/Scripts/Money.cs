using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum MoneyType
{
    Fake,
    Real
}

public class Money : MovementController
{
    public MoneyType moneyType;

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

        if (other.CompareTag(Tags.MoneyHolder))
        {
            isFinish = true;
            GetComponent<BoxCollider>().enabled = false;
            mT.DORotate(Vector3.up * (-90), 0.2f);
            NAEngine.DoubleCheckpointMove(mT, other.transform.position + Vector3.back * 10, other.transform.position ,1000,20);
        }
       /* if (other.CompareTag(Tags.MoneyHolder))
        {
            GetComponent<BoxCollider>().enabled = false;

            other.GetComponent<Animator>().SetTrigger("MoneyStack");
            MoveAnimation(other.transform, 12);
            //Delay.WaitForMe(EventManager.Fire_OnLevelCompleted, 1.5f);

            if (moneyType==MoneyType.Real)
            {
                 
            }

            else if (moneyType == MoneyType.Fake)
            {
                //Delay.WaitForMe(EventManager.Fire_OnLevelCompleted, 1f);
                //Noo!  -10 coin
            }
        }*/

        else if (other.CompareTag(Tags.PaperShredder))
        {
            GetComponent<BoxCollider>().enabled = false;

            other.GetComponent<Animator>().SetTrigger("MoneyShredStart");

            mT.parent = other.transform;
            other.transform.DOShakePosition(1.2f, Vector3.up);

            MoveAnimation(other.transform, 14);
            NAEngine.Delay(EventManager.Fire_OnLevelCompleted, 1.5f);

            if (moneyType == MoneyType.Fake)
            {
                
            }
            else if (moneyType == MoneyType.Real)
            {
                
                //Noo!  -10 coin
            }



        }
    }

    

    void MoveAnimation(Transform tr, float z)
    {
        isFinish = true;
        mT.DOMoveX(tr.position.x, 0.2f);
        mT.DORotate(Vector3.up * (-90), 0.3f);
        NAEngine.Delay(() => mT.DOMoveZ(z, 0.7f), 0.3f);

        
    }



}